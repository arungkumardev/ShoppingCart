using ShoppingCart.Integration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Service
{
    public class ConsoleService : IConsole
    {
        public string ReadLine() => Console.ReadLine();


        public void WriteLine(string input) => Console.WriteLine(input);
       
    }
}
