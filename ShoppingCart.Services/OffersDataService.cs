
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Integration;
using ShoppingCart.DTO;

namespace ShoppingCart.Service
{
    public class OffersDataService: IOffersData
    {
        private List<Offer> OfferList = new List<Offer>() {
            new Offer { Id=1,ItemId= 3,PayFor=1,GetQuantity=2 ,IsActive=true} ,
           new Offer { Id=2,ItemId= 4,PayFor=2,GetQuantity=3 ,IsActive=true} 
        };

        public List<Offer> GetOfferList()
        {
            try
            {
                return OfferList.Where(s => s.IsActive).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
