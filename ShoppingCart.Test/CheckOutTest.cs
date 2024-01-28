using Moq;
using ShoppingCart.Integration;
using ShoppingCart.Service;
using System.Linq;
using Xunit;

namespace ShoppingCart.Test
{
    public class CheckOutTest
    {

        [Theory]
        [InlineData(new string[5] { "Apple", "Apple", "Apple", "Apple", "Apple" }, 175)]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Melon", "Lime" }, 170)]
        [InlineData(new string[5] { "Apple", "Banana", "Melon", "Melon", "Lime" }, 135)]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Lime", "Lime" }, 120)]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Banana", "Banana" }, 130)]
        public void CalculateCartForYesTest(string[] cartItems, decimal expectedValue)
        {
            IItemData itemData = new ItemsDataService();
            IOffersData offerData = new OffersDataService();
            var mockConsoleService = new Mock<IConsole>();
            mockConsoleService.Setup(service => service.ReadLine()).Returns("Y");

            Checkout checkOut = new Checkout(itemData, offerData, mockConsoleService.Object);
            decimal result = checkOut.CalculateCart(cartItems.ToList());
            Assert.Equal(expectedValue, result);

        }

        [Theory]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Melon", "Lime" }, 155)]
        [InlineData(new string[5] { "Apple", "Banana", "Melon", "Melon", "Lime" }, 120)]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Lime", "Lime" }, 120)]
        [InlineData(new string[5] { "Apple", "Apple", "Banana", "Banana", "Banana" }, 130)]
        public void CalculateCartForNoTest(string[] cartItems, decimal expectedValue)
        {
            IItemData itemData = new ItemsDataService();
            IOffersData offerData = new OffersDataService();
            var mockConsoleService = new Mock<IConsole>();
            mockConsoleService.Setup(service => service.ReadLine()).Returns("N");

            Checkout checkOut = new Checkout(itemData, offerData, mockConsoleService.Object);
            decimal result = checkOut.CalculateCart(cartItems.ToList());
            Assert.Equal(expectedValue, result);
        }
    }
}
