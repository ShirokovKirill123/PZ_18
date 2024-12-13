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

        private ObservableCollection<Data_BusinessLogic.Model.Customers> _customers;
        public ObservableCollection<Data_BusinessLogic.Model.Customers> Customers
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
                Customers = new ObservableCollection<Data_BusinessLogic.Model.Customers>
            {
                new Data_BusinessLogic.Model.Customers { registrationDate = DateTime.Now, userID = 1 },
                new Data_BusinessLogic.Model.Customers { registrationDate = DateTime.Now, userID = 2 }
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
