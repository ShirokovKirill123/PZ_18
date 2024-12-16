using System.ComponentModel;
using System;
using Data_BusinessLogic;
using Data_BusinessLogic.DB;
using Xunit;
using Data_BusinessLogic.Model;


namespace TestProject
{
    public class RepairPartsTests
    {
        [Fact]
        public void RepairParts_Should_Update_Price()
        {
            var part = new RepairParts();
            var newPrice = 200.5m;

            part.price = newPrice;

            Assert.Equal(newPrice, part.price);
        }

        [Fact]
        public void RepairParts_Should_Set_Properties_Correctly()
        {
            var partName = "Батарея";
            var price = 99.99m;
            var stockQuantity = 15;

            var part = new RepairParts
            {
                partName = partName,
                price = price,
                stockQuantity = stockQuantity
            };

            Assert.Equal(partName, part.partName);
            Assert.Equal(price, part.price);
            Assert.Equal(stockQuantity, part.stockQuantity);
        }
    }
}
