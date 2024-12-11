using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data_BusinessLogic.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { get; set; }

        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private ObservableCollection<Customers> _customers;
        public ObservableCollection<Customers> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private string _welcomeMessage = "Добро пожаловать в приложение!";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged(nameof(WelcomeMessage));
            }
        }

        private bool _isLoggedIn = false;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public void LoadCustomers()
        {
                Customers = new ObservableCollection<Customers>
            {
                new Customers { RegistrationDate = DateTime.Now, UserID = 1 },
                new Customers { RegistrationDate = DateTime.Now, UserID = 2 }
            };
        }

        private void ExecuteLogin(object parameter)
        {
            IsLoggedIn = true;
            LoadCustomers();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
