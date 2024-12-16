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

            if (Data_BusinessLogic.Manager.UserId.HasValue)
            {
                using (var context = new EquipmentRepairSystemEntities4())
                {
                    var currentUser = context.Users.FirstOrDefault(u => u.userID == Data_BusinessLogic.Manager.UserId.Value);
                    if (currentUser != null)
                    {
                        FioTextBox.Text = currentUser.fio;
                        PhoneNumberTextBox.Text = currentUser.phone;
                        LoginTextBox.Text = currentUser.C_login;
                        PasswordNumberTextBox.Text = currentUser.C_password;
                    }
                }
            }
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
                Users existingUser;

                if (Data_BusinessLogic.Manager.UserId.HasValue)
                {
                    existingUser = context.Users.FirstOrDefault(u => u.userID == Data_BusinessLogic.Manager.UserId.Value);
                }
                else
                {
                    existingUser = context.Users.FirstOrDefault(u => u.C_login == LoginTextBox.Text);

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
                        existingUser = newUser;
                    }
                }

                
                if (existingUser != null)
                {
                    if (existingUser.C_login != LoginTextBox.Text || existingUser.C_password != PasswordNumberTextBox.Text)
                    {
                        MessageBox.Show("Введенные логин или пароль неверны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден. Обратитесь в поддержку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var existingCustomer = context.Customers.FirstOrDefault(c => c.userID == existingUser.userID);
                if (existingCustomer == null)
                {
                    existingCustomer = new Customers
                    {
                        registrationDate = DateTime.Now,
                        userID = existingUser.userID
                    };
                    context.Customers.Add(existingCustomer);
                    context.SaveChanges();
                }

                var newRequest = new Requests
                {
                    customerID = existingCustomer.customerID,
                    startDate = DateTime.Now,
                    completionDate = DateTime.Now.AddDays(7),
                    typeOfRequest = "Ремонт",
                    technicType = TechnicTypeTextBox.Text,
                    technicModel = TechnicModelTextBox.Text,
                    problemDescription = ProblemDescriptionTextBox.Text,
                    C_status = "Новый",
                    sparePartID = 1,
                    managerID = 1,
                    masterID = 1
                };

                context.Requests.Add(newRequest);
                context.SaveChanges();
            }

            MessageBox.Show("Заявка успешно составлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
