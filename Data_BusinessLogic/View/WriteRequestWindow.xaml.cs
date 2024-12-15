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
    /// Логика взаимодействия для WriteRequestWindow.xaml
    /// </summary>
    public partial class WriteRequestWindow : Window
    {
        public WriteRequestWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubmitRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FioTextBox.Text) ||
                string.IsNullOrWhiteSpace(TechnicTypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(TechnicModelTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProblemDescriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            using (var context = new EquipmentRepairSystemEntities4())
            {
                var clientFio = FioTextBox.Text;

                var existingUser = context.Users.FirstOrDefault(u => u.fio == clientFio);

                if (existingUser == null)
                {
                    var newUser = new Users
                    {
                        fio = clientFio,
                        phone = PhoneNumberTextBox.Text,
                        C_login = LoginTextBox.Text,
                        C_password = PasswordNumberTextBox.Text,
                        C_type = 2
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    var newCustomer = new Customers
                    {
                        registrationDate = DateTime.Now,
                        userID = newUser.userID 
                    };
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();

                    existingUser = newUser;
                }
                else
                {
                    existingUser.fio = clientFio; 
                    context.SaveChanges();
                }

                var existingCustomer = context.Customers.FirstOrDefault(c => c.userID == existingUser.userID);

                if (existingCustomer == null)
                {
                    var newCustomer = new Customers
                    {
                        registrationDate = DateTime.Now,
                        userID = existingUser.userID
                    };
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    existingCustomer = newCustomer;
                }

                var newRequest = new Requests
                {
                    Customers = existingCustomer,
                    startDate = DateTime.Now,
                    completionDate = DateTime.Now.AddDays(7),
                    typeOfRequest = "Ремонт",
                    technicType = TechnicTypeTextBox.Text,
                    technicModel = TechnicModelTextBox.Text,
                    problemDescription = ProblemDescriptionTextBox.Text,
                    C_status = "Новый",
                    sparePartID = 1,
                    customerID = existingCustomer.customerID,
                    managerID = 1,
                    masterID = 1
                };

                context.Requests.Add(newRequest);
                context.SaveChanges();
            }

            MessageBox.Show("Заявка успешно оставлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
