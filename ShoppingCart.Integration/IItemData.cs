using ShoppingCart.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Integration
{
    public interface IItemData
    {
        List<Item> GetItemsList();
    }
}
