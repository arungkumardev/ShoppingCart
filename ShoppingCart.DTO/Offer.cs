using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DTO
{
    public class Offer
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PayFor { get; set; }
        public int GetQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
