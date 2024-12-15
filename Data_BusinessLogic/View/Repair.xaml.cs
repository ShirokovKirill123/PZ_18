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
    /// Логика взаимодействия для Repair.xaml
    /// </summary>
    public partial class Repair : Window
    {
        public Repair()
        {
            InitializeComponent();
            LoadStatusOptions();
            LoadRepairParts();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadStatusOptions()
        {
            StatusComboBox.ItemsSource = new[] { "В процессе", "Завершено" };
        }

        private void LoadRepairParts()
        {
            using (var context = new EquipmentRepairSystemEntities4())
            {
                var repairParts = context.RepairParts.Select(rp => new
                {
                    rp.sparePartID,
                    rp.partName
                }).ToList();
                RepairPartComboBox.ItemsSource = repairParts;
                RepairPartComboBox.DisplayMemberPath = "partName"; 
                RepairPartComboBox.SelectedValuePath = "sparePartID"; 
            }
        }

        private void ProcessRepairButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RequestIdTextBox.Text) ||
                string.IsNullOrWhiteSpace(RequestTypeTextBox.Text) ||
                StatusComboBox.SelectedItem == null ||
                RepairPartComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new EquipmentRepairSystemEntities4())
            {
                var repairId = int.Parse(RequestIdTextBox.Text);

                var repair = context.Requests.FirstOrDefault(r => r.requestID == repairId);

                if (repair == null)
                {
                    MessageBox.Show("Заявка с указанным ID не найдена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                repair.C_status = StatusComboBox.SelectedItem.ToString(); 
                repair.typeOfRequest = RequestTypeTextBox.Text;          
                repair.sparePartID = (int)RepairPartComboBox.SelectedValue; 

                context.SaveChanges();
                MessageBox.Show("Ремонт успешно обработан!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
