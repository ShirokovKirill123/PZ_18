using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;
using Data_BusinessLogic.Model;


namespace TestProject
{
    public class RequestTest
    {
        [Fact]
        public void Request_Should_Update_CompletionDate()
        {
            var request = new Requests();
            var newCompletionDate = DateTime.Now;

            request.completionDate = newCompletionDate;

            Assert.Equal(newCompletionDate, request.completionDate);
        }

        [Fact]
        public void Request_Should_Set_Properties_Correctly()
        {
            var startDate = DateTime.Now;
            var problemDescription = "Device not working";
            var typeOfRequest = "Repair";
            var technicType = "Phone";
            var technicModel = "iPhone 12";
            var status = "Pending";
            var sparePartID = 1;
            var customerID = 2;
            var masterID = 2;
            var managerID = 1;

            var request = new Requests
            {
                startDate = startDate,
                problemDescription = problemDescription,
                typeOfRequest = typeOfRequest,
                technicType = technicType,
                technicModel = technicModel,
                C_status = status,
                sparePartID = sparePartID,
                customerID = customerID,
                masterID = masterID,
                managerID = managerID
            };

            Assert.Equal(startDate, request.startDate);
            Assert.Equal(problemDescription, request.problemDescription);
            Assert.Equal(typeOfRequest, request.typeOfRequest);
            Assert.Equal(technicType, request.technicType);
            Assert.Equal(technicModel, request.technicModel);
            Assert.Equal(status, request.C_status);
            Assert.Equal(sparePartID, request.sparePartID);
            Assert.Equal(customerID, request.customerID);
            Assert.Equal(masterID, request.masterID);
            Assert.Equal(managerID, request.managerID);
        }
    }
}
