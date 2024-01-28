using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Integration
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string input);
    }
}
