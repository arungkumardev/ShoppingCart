using ShoppingCart.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Integration;

namespace ShoppingCart
{
    public class Checkout
    {
        private readonly IItemData _itemData;
        private readonly IOffersData _offerData;
        private readonly IConsole _console;
        public Checkout(IItemData itemData, IOffersData offerData, IConsole console)
        {
            _itemData = itemData;
            _offerData = offerData;
            _console = console;
        }

        public decimal CalculateCart(List<string> cartItems)
        {
            try
            {
                Decimal FinalPrice = 0;
                List<Item> itemList = _itemData.GetItemsList();
                List<Offer> offerList = _offerData.GetOfferList();

                var ItemCount = cartItems.GroupBy(s => s).Select(s => new { Item = s.Key, Count = s.Count() })
                    .Join(itemList, cart => cart.Item.ToLower(), item => item.Name.ToLower(), (cart, item) => new
                    {
                        Item = item,
                        Count = cart.Count
                    }).GroupJoin(offerList, itemCount => itemCount.Item.Id, offer => offer.ItemId, (itemCount, offer) => new
                    {
                        Item = itemCount.Item,
                        Offer = offer.FirstOrDefault(),
                        Count = itemCount.Count
                    }).ToList();

                ItemCount.ForEach(s =>
                {
                    if (s.Offer != null)
                    {
                        int reminder = s.Count % s.Offer.GetQuantity;
                       
                        if (reminder != 0)
                        {
                            _console.WriteLine($"Buy {s.Offer.GetQuantity} {s.Item.Name} for price of {s.Offer.PayFor}");
                            _console.WriteLine("Press Y to avail the offer, Press N to continue without offer");
                            string input = _console.ReadLine();
                            if (input == "Y")
                            {
                                Console.WriteLine("adding {0} {1} to the cart", s.Item.Name, reminder);
                                if (s.Count < s.Offer.GetQuantity)
                                {
                                    reminder = s.Offer.GetQuantity - s.Count;
                                }
                                FinalPrice += ((s.Count + reminder) / s.Offer.GetQuantity) * (s.Item.Price * s.Offer.PayFor);
                            }
                            else
                            {
                                FinalPrice += ((s.Count / s.Offer.GetQuantity) * (s.Item.Price * s.Offer.PayFor)) + (reminder * s.Item.Price);
                            }
                        }
                        else
                        {
                            FinalPrice += (s.Count / s.Offer.GetQuantity) * (s.Item.Price * s.Offer.PayFor);
                        }
                    }
                    else
                    {
                        FinalPrice += s.Count * s.Item.Price;
                    }
                });
                return FinalPrice;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
