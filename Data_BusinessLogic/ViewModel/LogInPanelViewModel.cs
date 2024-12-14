using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data_BusinessLogic.ViewModel
{
    public class LogInPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LogInCommand { get; set; }

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _statusMessage = "Пожалуйста, войдите.";
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public LogInPanelViewModel()
        {
            LogInCommand = new RelayCommand(ExecuteLogIn);
        }

        private void ExecuteLogIn(object parameter)
        {
            if (ValidateCredentials(Login, Password))
            {
                StatusMessage = "Вход успешен!";
            }
            else
            {
                StatusMessage = "Неверный логин или пароль.";
            }
        }

        private bool ValidateCredentials(string login, string password)
        {
            return login == "admin" && password == "admin"; 
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

