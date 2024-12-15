using Data_BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using System.Data.Entity; // Для Entity Framework 6
using System.IO;
using static System.Collections.Specialized.BitVector32;


namespace Data_BusinessLogic.View
{
    /// <summary>
    /// Логика взаимодействия для Сlient.xaml
    /// </summary>
    public partial class Сlient : Window
    {
        private string currentTable;

        public Сlient()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.Visibility = SideMenu.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SideMenu.Visibility == Visibility.Visible)
            {
                Point clickPosition = e.GetPosition(this);

                if (!IsPointInsideElement(SideMenu, clickPosition) && !IsPointInsideElement(MenuButton, clickPosition))
                {
                    SideMenu.Visibility = Visibility.Hidden;
                }
            }
        }
        private bool IsPointInsideElement(FrameworkElement element, Point point)
        {
            Rect bounds = new Rect(element.TranslatePoint(new Point(0, 0), this), element.RenderSize);

            return bounds.Contains(point);
        }       

        private void Button_Requests_Click(object sender, RoutedEventArgs e)
        {
            if (Data_BusinessLogic.Manager.UserType != 2 || Data_BusinessLogic.Manager.UserId == null)
            {
                MessageBox.Show("Недостаточно прав для просмотра заявок", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new EquipmentRepairSystemEntities4())
            {
                DataGrid.ContextMenu = null;

                int clientId = Data_BusinessLogic.Manager.UserId.Value; 

                var requestsList = from r in context.Requests
                                   where r.customerID == clientId
                                   let clientFio = r.Customers != null && r.Customers.Users != null ? r.Customers.Users.fio : string.Empty
                                   let managerFio = r.Managers != null && r.Managers.Users != null ? r.Managers.Users.fio : string.Empty
                                   let masterFio = r.Masters != null && r.Masters.Users != null ? r.Masters.Users.fio : string.Empty
                                   let partName = r.RepairParts != null ? r.RepairParts.partName : string.Empty
                                   select new Model.DB.RequestDTO
                                   {
                                       RequestID = r.requestID,
                                       StartDate = r.startDate,
                                       CompletionDate = r.completionDate,
                                       TechnicType = r.technicType,
                                       TechnicModel = r.technicModel,
                                       ProblemDescription = r.problemDescription,
                                       ClientFio = clientFio,
                                       ManagerFio = managerFio,
                                       MasterFio = masterFio,
                                       PartName = partName,
                                       TypeOfRequest = r.typeOfRequest,
                                       Status = r.C_status
                                   };

                var result = requestsList.ToList();

                DataGrid.ItemsSource = result;
                currentTable = "Requests";

                if (!result.Any())
                {
                    MessageBox.Show("У вас нет заявок", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                DataGrid.Columns.Clear();

                DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("RequestID") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата начала", Binding = new Binding("StartDate") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата завершения", Binding = new Binding("CompletionDate") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Тип техники", Binding = new Binding("TechnicType") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Модель", Binding = new Binding("TechnicModel") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Описание проблемы", Binding = new Binding("ProblemDescription") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Клиент", Binding = new Binding("ClientFio") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Менеджер", Binding = new Binding("ManagerFio") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Мастер", Binding = new Binding("MasterFio") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Запчасть", Binding = new Binding("PartName") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Тип заявки", Binding = new Binding("TypeOfRequest") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Статус", Binding = new Binding("Status") });
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                switch (currentTable)
                {                    
                    case "Requests":
                        var newRequest = new Requests
                        {
                            startDate = DateTime.Now,
                            completionDate = DateTime.Now.AddDays(7),
                            typeOfRequest = "Ремонт",
                            technicType = "Тип",
                            technicModel = "Модель",
                            problemDescription = "описание",
                            C_status = "Новый",
                            sparePartID = 1,
                            customerID = 1,
                            managerID = 1,
                            masterID = 1
                        };
                        context.Requests.Add(newRequest);
                        break;

                    default:
                        MessageBox.Show("Неизвестная таблица для добавления.");
                        return;
                }

                try
                {
                    context.SaveChanges();
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {                
                if (currentTable == "Requests")
                {
                    var requestsFromGrid = DataGrid.ItemsSource as List<Requests>;
                    if (requestsFromGrid != null)
                    {
                        foreach (var request in requestsFromGrid)
                        {
                            if (request.requestID == 0)
                            {
                                context.Requests.Add(request);
                            }
                            else
                            {
                                var existingRequest = context.Requests.Find(request.requestID);
                                if (existingRequest != null)
                                {
                                    context.Entry(existingRequest).CurrentValues.SetValues(request);
                                }
                            }
                        }
                        context.SaveChanges();
                    }
                }

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string inputID = TextBoxID.Text;

            if (string.IsNullOrEmpty(inputID))
            {
                MessageBox.Show("Введите ID удаляемого элемента");
                return;
            }

            int deleteID = int.Parse(inputID);

            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить элемент с ID {deleteID}?", "Подтверждение удаления", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            using (var context = new EquipmentRepairSystemEntities4())
            {
                dynamic itemToDelete = null;

                switch (currentTable)
                {
                    case "Requests":
                        itemToDelete = context.Requests.FirstOrDefault(si => si.requestID == deleteID);
                        break;

                    default:
                        MessageBox.Show("Неизвестная таблица.");
                        return;
                }

                if (itemToDelete == null)
                {
                    MessageBox.Show($"Запись с ID {deleteID} не найдена.");
                    return;
                }

                context.Set(itemToDelete.GetType()).Remove(itemToDelete);

                context.SaveChanges();

                MessageBox.Show($"Запись с ID {deleteID} была успешно удалена.");
                RefreshDataGrid();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            switch (currentTable)
            {              
                case "Requests":
                    Button_Requests_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void Button_WriteARequest_Click(object sender, RoutedEventArgs e)
        {
            WriteRequestWindow writeRequestWindow = new WriteRequestWindow();
            writeRequestWindow.ShowDialog();
        }
       
        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var data = DataGrid.ItemsSource as IEnumerable<object>;
            if (data == null || !data.Any())
            {
                MessageBox.Show("Нет данных для экспорта");
                return;
            }

            // Реализация экспорта в CSV
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                FileName = "Отчёт.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    var properties = data.First().GetType().GetProperties();
                    writer.WriteLine(string.Join(";", properties.Select(p => p.Name)));

                    foreach (var item in data)
                    {
                        var values = properties.Select(p => p.GetValue(item)?.ToString());
                        writer.WriteLine(string.Join(";", values));
                    }
                }

                MessageBox.Show("Отчёт успешно экспортирован");
            }
        }
    }
}
