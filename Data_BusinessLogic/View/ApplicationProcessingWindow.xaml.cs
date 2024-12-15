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

namespace Data_BusinessLogic.View
{
    /// <summary>
    /// Логика взаимодействия для ApplicationProcessingWindow.xaml
    /// </summary>
    public partial class ApplicationProcessingWindow : Window
    {
        public ApplicationProcessingWindow()
        {
            InitializeComponent();
            LoadManagersAndMasters();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadManagersAndMasters()
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                var managers = context.Managers.Select(m => new
                {
                    m.managerID,
                    m.Users.fio
                }).ToList();
                ManagerComboBox.ItemsSource = managers;

                var masters = context.Masters.Select(m => new
                {
                    m.masterID,
                    m.Users.fio
                }).ToList();
                MasterComboBox.ItemsSource = masters;
            }
        }

        private void ButtonApplicationProcessing_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RequestIdTextBox.Text) ||
                CompletionDatePicker.SelectedDate == null ||
                ManagerComboBox.SelectedValue == null ||
                MasterComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new EquipmentRepairSystemEntities4())
            {
                var requestId = int.Parse(RequestIdTextBox.Text);
                var request = context.Requests.FirstOrDefault(r => r.requestID == requestId);

                if (request == null)
                {
                    MessageBox.Show("Заявка с указанным ID не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                request.completionDate = CompletionDatePicker.SelectedDate.Value;
                request.managerID = (int)ManagerComboBox.SelectedValue;
                request.masterID = (int)MasterComboBox.SelectedValue;
                request.C_status = "В процессе";

                context.SaveChanges();
                MessageBox.Show("Заявка успешно обработана!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
