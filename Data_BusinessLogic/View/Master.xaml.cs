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

namespace Data_BusinessLogic.View
{
    /// <summary>
    /// Логика взаимодействия для Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        private string currentTable;

        public Master()
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

        private void StackPanelVisibility()
        {
            if (DataGrid.Items.Count == 0)
            {
                StackPanel2.Visibility = Visibility.Hidden;
            }
            else
            {
                StackPanel2.Visibility = Visibility.Visible;
            }
        }              
       
        private void Button_Masters_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                DataGrid.ContextMenu = null;

                var mastersList = context.Masters
                    .Include(m => m.Users)
                    .Include(m => m.Specializations)
                    .ToList();

                DataGrid.ItemsSource = mastersList;
                currentTable = "Masters";

                DataGrid.Columns.Clear();

                DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("masterID") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Специализация", Binding = new Binding("Specializations.nameOfSpecialization") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Пользователь", Binding = new Binding("Users.fio") });

                StackPanelVisibility();
            }
        }        

        private void Button_RepairParts_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                DataGrid.ContextMenu = null;

                var repairPartsList = context.RepairParts.ToList();

                DataGrid.ItemsSource = repairPartsList;
                currentTable = "RepairParts";

                DataGrid.Columns.Clear();

                DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("sparePartID") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Название запчасти", Binding = new Binding("partName") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("price") });
                DataGrid.Columns.Add(new DataGridTextColumn { Header = "Количество на складе", Binding = new Binding("stockQuantity") });

                StackPanelVisibility();
            }
        }

        private void Button_Requests_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                DataGrid.ContextMenu = null;

                var requestsList = from r in context.Requests
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

                StackPanelVisibility();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                switch (currentTable)
                {                   
                    case "Masters":
                        var newMaster = new Masters
                        {
                            userID = 1,
                            specialization = 1
                        };
                        context.Masters.Add(newMaster);
                        break;

                    case "RepairParts":
                        var newRepairPart = new RepairParts
                        {
                            partName = "запчасть",
                            price = 0m,
                            stockQuantity = 0
                        };
                        context.RepairParts.Add(newRepairPart);
                        break;

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
                if (currentTable == "Masters")
                {
                    var mastersFromGrid = DataGrid.ItemsSource as List<Masters>;
                    if (mastersFromGrid != null)
                    {
                        foreach (var master in mastersFromGrid)
                        {
                            if (master.masterID == 0)
                            {
                                context.Masters.Add(master);
                            }
                            else
                            {
                                var existingMaster = context.Masters.Find(master.masterID);
                                if (existingMaster != null)
                                {
                                    context.Entry(existingMaster).CurrentValues.SetValues(master);
                                }
                            }
                        }
                        context.SaveChanges();
                    }
                }              
                else if (currentTable == "RepairParts")
                {
                    var repairPartsFromGrid = DataGrid.ItemsSource as List<RepairParts>;
                    if (repairPartsFromGrid != null)
                    {
                        foreach (var repairPart in repairPartsFromGrid)
                        {
                            if (repairPart.sparePartID == 0)
                            {
                                context.RepairParts.Add(repairPart);
                            }
                            else
                            {
                                var existingRepairPart = context.RepairParts.Find(repairPart.sparePartID);
                                if (existingRepairPart != null)
                                {
                                    context.Entry(existingRepairPart).CurrentValues.SetValues(repairPart);
                                }
                            }
                        }
                        context.SaveChanges();
                    }
                }
                else if (currentTable == "Requests")
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
                    case "Masters":
                        itemToDelete = context.Masters.FirstOrDefault(op => op.masterID == deleteID);
                        break;
                 
                    case "RepairParts":
                        itemToDelete = context.RepairParts.FirstOrDefault(pc => pc.sparePartID == deleteID);
                        break;

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
                case "Masters":
                    Button_Masters_Click(null, null);
                    break;                
                case "RepairParts":
                    Button_RepairParts_Click(null, null);
                    break;
                case "Requests":
                    Button_Requests_Click(null, null);
                    break;
                default:
                    break;
            }
        } 

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Repair repairWindow = new Repair();
            repairWindow.ShowDialog();
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
