using System;
using ShoppingCart.DTO;
using System.Collections.Generic;

using ShoppingCart.Integration;

namespace ShoppingCart.Service
{
    public class ItemsDataService:IItemData
    {
        private List<Item> ItemsList = new List<Item>() {
            new Item { Id=1,Name= "Apple",Price=35 } ,
            new Item { Id=2,Name= "Banana",Price=20 },
            new Item { Id=3,Name= "Melon",Price=50 },
            new Item { Id=4,Name= "Lime",Price=15 }
        };

        public List<Item> GetItemsList()
        {
            try {
                return ItemsList;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
