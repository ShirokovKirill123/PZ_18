using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;
using Data_BusinessLogic.Model;

namespace TestProject
{
    public class UserTest
    {
        [Fact]
        public void User_Should_Update_Login()
        {
            var user = new Users();
            var newLogin = "NewLogin";

            user.C_login = newLogin;

            Assert.Equal(newLogin, user.C_login);
        }

        [Fact]
        public void User_Should_Set_Properties_Correctly()
        {
            var expectedLogin = "test_user";
            var expectedPassword = "password123";
            var expectedPhone = "1234567890";
            var expectedFio = "Reo Mickage";
            var expectedType = 1;

            var user = new Users
            {
                C_login = expectedLogin,
                C_password = expectedPassword,
                phone = expectedPhone,
                fio = expectedFio,
                C_type = expectedType
            };

            Assert.Equal(expectedLogin, user.C_login);
            Assert.Equal(expectedPassword, user.C_password);
            Assert.Equal(expectedPhone, user.phone);
            Assert.Equal(expectedFio, user.fio);
            Assert.Equal(expectedType, user.C_type);
        }

        [Fact]
        public void User_Should_Have_Empty_Collections_By_Default()
        {            
            var user = new Users();
             
            var customersCount = user.Customers.Count;
            var managersCount = user.Managers.Count;
            var mastersCount = user.Masters.Count;

            
            Assert.Empty(user.Customers);
            Assert.Empty(user.Managers);
            Assert.Empty(user.Masters);
        }

        [Fact]
        public void User_Should_Allow_Adding_To_Collections()
        {
            
            var user = new Users();
            var customer = new Customers();
            var manager = new Managers();
            var master = new Masters();

            
            user.Customers.Add(customer);
            user.Managers.Add(manager);
            user.Masters.Add(master);

            Assert.Contains(customer, user.Customers);
            Assert.Contains(manager, user.Managers);
            Assert.Contains(master, user.Masters);
        }
    }
}