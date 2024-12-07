using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;

namespace UnitTestObject
{
    public class UserTests
    {
        [Fact]
        public void User_Should_Trigger_PropertyChanged_When_Login_Changes()
        {
            var user = new User();
            bool propertyChangedTriggered = false;
            user.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(User.Login))
                    propertyChangedTriggered = true;
            };
           
            user.Login = "NewLogin";

            Assert.True(propertyChangedTriggered);
        }

        [Fact]
        public void User_Should_Have_Required_Properties()
        {
            var user = new User
            {
                Login = "test_user",
                Password = "password123",
                Phone = 1234567890,
                Name = "John",
                Surname = "Doe",
                LastName = "Smith",
                UserTypeId = 1
            };

            Assert.Equal("test_user", user.Login);
            Assert.Equal("password123", user.Password);
            Assert.Equal(1234567890, user.Phone);
            Assert.Equal("John", user.Name);
            Assert.Equal("Doe", user.Surname);
            Assert.Equal("Smith", user.LastName);
            Assert.Equal(1, user.UserTypeId);
        }
    }
}
