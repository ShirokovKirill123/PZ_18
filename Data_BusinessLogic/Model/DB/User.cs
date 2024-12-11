using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Data_BusinessLogic.DB.Interface;

namespace Data_BusinessLogic.DB
{
    public class User : IUsers, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; private set; }

        private string login;
        [Required]
        [MaxLength(125)]
        [JsonPropertyName("login")]
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password;
        [Required]
        [MaxLength(50)]
        [JsonIgnore] // Не сериализуем пароль для безопасности
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private long phone;
        [Required]
        [JsonPropertyName("phone")]
        public long Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string name;
        [Required]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string surname;
        [MaxLength(256)]
        [JsonPropertyName("surname")]
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string lastName;
        [MaxLength(256)]
        [JsonPropertyName("lastName")]
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private int userTypeId;
        [Required]
        [JsonPropertyName("userTypeId")]
        public int UserTypeId
        {
            get => userTypeId;
            set
            {
                userTypeId = value;
                OnPropertyChanged(nameof(UserTypeId));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool ValidatePassword(string password)
        {
            return password == Password;
        }
    }
}
