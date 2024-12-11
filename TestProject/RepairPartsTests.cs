using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;


namespace TestProject
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
                PartName = "Screen",
                Price = 150,
                StockQuantity = 20
            };

            Assert.Equal("Screen", part.PartName);
            Assert.Equal(150, part.Price);
            Assert.Equal(20, part.StockQuantity);
        }
    }
}
