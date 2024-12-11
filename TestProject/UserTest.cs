using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;

namespace TestProject
{
    public class UserTest
    {
        [Fact]
        public void User_Should_Trigger_PropertyChanged_When_Login_Changes()
        {
            var user = new Users();
            bool propertyChangedTriggered = false;
            user.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Users.C_Login))
                    propertyChangedTriggered = true;
            };

            user.C_Login = "NewLogin";

            Assert.True(propertyChangedTriggered);
        }

        [Fact]
        public void User_Should_Set_Properties_Correctly()
        {
            var user = new Users
            {
                C_Login = "test_user",
                C_Password = "password123",
                Phone = "1234567890",
                Fio = "John Doe",
                C_Type = 1
            };

            Assert.Equal("test_user", user.C_Login);
            Assert.Equal("password123", user.C_Password);
            Assert.Equal("1234567890", user.Phone);
            Assert.Equal("John Doe", user.Fio);
            Assert.Equal(1, user.C_Type);
        }
    }
}