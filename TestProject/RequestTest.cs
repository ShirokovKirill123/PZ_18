using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;


namespace TestProject
{
    public class RequestTest
    {
        [Fact]
        public void Request_Should_Trigger_PropertyChanged_When_CompletionDate_Changes()
        {
            var request = new Requests();
            bool propertyChangedTriggered = false;
            request.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Requests.CompletionDate))
                    propertyChangedTriggered = true;
            };

            request.CompletionDate = DateTime.Now;

            Assert.True(propertyChangedTriggered);
        }

        [Fact]
        public void Request_Should_Set_Properties_Correctly()
        {
            var request = new Requests
            {
                StartDate = DateTime.Now,
                ProblemDescription = "Device not working",
                TypeOfRequest = "Repair",
                TechnicType = "Phone",
                TechnicModel = "iPhone 12",
                C_Status = "Pending",
                SparePartID = 1,
                CustomerID = 2,
                MasterID = 2,
                ManagerID = 1
            };

            Assert.Equal("Repair", request.TypeOfRequest);
            Assert.Equal("Phone", request.TechnicType);
            Assert.Equal("iPhone 12", request.TechnicModel);
            Assert.Equal("Pending", request.C_Status);
            Assert.Equal(1, request.SparePartID);
            Assert.Equal(2, request.CustomerID);
            Assert.Equal(2, request.MasterID);
            Assert.Equal(1, request.ManagerID);
        }
    }
}
