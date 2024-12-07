using Data_BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestObject
{
    public class RepairPartsTests
    {
        [Fact]
        public void RepairParts_Should_Trigger_PropertyChanged_When_Price_Changes()
        {
            var part = new RepairParts();
            bool propertyChangedTriggered = false;
            part.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(RepairParts.Price))
                    propertyChangedTriggered = true;
            };

            part.Price = 100;
            
            Assert.True(propertyChangedTriggered);
        }

        [Fact]
        public void RepairParts_Should_Set_Properties_Correctly()
        {
            var part = new RepairParts
            {
                Name = "Screen",
                Price = 150
            };

            Assert.Equal("Screen", part.Name);
            Assert.Equal(150, part.Price);
        }
    }
}
