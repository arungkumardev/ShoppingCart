using System;
using System.Collections.Generic;
using ShoppingCart.Integration;
using ShoppingCart.Service;

namespace ShoppingCart.CheckOut
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Dependency Injection through constructor;
                List<string> cartItems = new List<string>() { "Apple", "Apple", "Banana", "Melon", "Lime" };
                IItemData itemData = new ItemsDataService();
                IOffersData offerData = new OffersDataService();
                IConsole console = new ConsoleService();
                Checkout checkOut = new Checkout(itemData, offerData,console);
                decimal FinalAmount = checkOut.CalculateCart(cartItems);
                console.WriteLine($"Total Amount {FinalAmount}p");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
