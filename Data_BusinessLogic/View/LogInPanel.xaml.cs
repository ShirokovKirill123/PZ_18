﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data_BusinessLogic.Model;
using Data_BusinessLogic.View;
using Data_BusinessLogic.ViewModel;
using static System.Collections.Specialized.BitVector32;

namespace Data_BusinessLogic.View
{
    /// <summary>
    /// Логика взаимодействия для LogInPanel.xaml
    /// </summary>
    public partial class LogInPanel : Window
    {
        public LogInPanel()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new EquipmentRepairSystemEntities4())
            {
                var user = context.Users.AsNoTracking().FirstOrDefault(u => u.C_login == username && u.C_password == password);

                if (user != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    Admin adminWindow = new Admin();
                    View.Manager managerWindow = new View.Manager();
                    Master masterWindow = new Master();
                    Сlient clientWindow = new Сlient();

                    if (user.C_type == 1)//Админ
                    {
                        adminWindow.Show();
                    }
                    else if (user.C_type == 2)//Клиент
                    {
                        Data_BusinessLogic.Manager.UserId = user.userID; 
                        Data_BusinessLogic.Manager.UserType = "Client";
                        clientWindow.Show();
                    }
                    else if (user.C_type == 3)//Мастер
                    {
                        masterWindow.Show();
                    }
                    else if (user.C_type == 4)//Менеджер
                    {
                        managerWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная роль пользователя");
                        return;
                    }
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
