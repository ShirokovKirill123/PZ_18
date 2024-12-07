using Data_BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestObject
{
    public class RequestTest
    {
        [Fact]
        public void Request_Should_Be_Completed_When_CompletionDate_Is_Set()
        {
            var request = new Request
            {
                StartDate = DateTime.Now,
                ProblemDescription = "Device not working",
                HomeTechTypeId = 1,
                ClientId = 1,
                StatusId = 1
            };

            request.CompletionDate = DateTime.Now;
            Assert.True(request.IsCompleted);
        }

        [Fact]
        public void Request_Should_Trigger_PropertyChanged_When_CompletionDate_Changes()
        {
            var request = new Request();
            bool propertyChangedTriggered = false;
            request.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Request.CompletionDate))
                    propertyChangedTriggered = true;
            };
           
            request.CompletionDate = DateTime.Now;

            Assert.True(propertyChangedTriggered);
        }
    }
}
