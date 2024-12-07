using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestObject
{
    public class ReqStatusTypeTests
    {
        [Fact]
        public void ReqStatusType_Should_Trigger_PropertyChanged_When_Name_Changes()
        {
            var status = new ReqStatusType();
            bool propertyChangedTriggered = false;
            status.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(ReqStatusType.Name))
                    propertyChangedTriggered = true;
            };

            status.Name = "Completed";

            Assert.True(propertyChangedTriggered);
        }
    }
}
