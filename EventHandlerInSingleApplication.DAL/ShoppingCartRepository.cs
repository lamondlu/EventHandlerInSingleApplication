using System;
using System.Collections.Generic;
using System.Text;
using EventHandlerInSingleApplication.Models.ViewModels;
using System.Linq;

namespace EventHandlerInSingleApplication.DAL
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public ShoppingCartViewModel GetShoppingCart(string shoppingCartId)
        {
            var shoppingCart = DataStore.ShoppingCarts.First(p => p.ShoppingCartId == shoppingCartId);
            return new ShoppingCartViewModel
            {
                ShoppingCartId = shoppingCart.ShoppingCartId,
                Items = shoppingCart.Items.Select(p => new ShoppingCartItemViewModel
                {
                    ItemId = p.ItemId,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };
        }

        public void SubmitShoppingCart(string shoppingCartId)
        {
            var shoppingCart = DataStore.ShoppingCarts.First(p => p.ShoppingCartId == shoppingCartId);
            shoppingCart.IsSubmit = true;
        }

        public string CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCart();
            DataStore.ShoppingCarts.Add(shoppingCart);

            return shoppingCart.ShoppingCartId;
        }

        public void AddItemToShippingCart(string shoppingCartId, string itemId)
        {
            var shoppingCart = DataStore.ShoppingCarts.First(p => p.ShoppingCartId == shoppingCartId);
            var item = DataStore.Items.First(p => p.ItemId == itemId);
            shoppingCart.Items.Add(item);
        }

        public List<ItemViewModel> GetAllItems()
        {
            return DataStore.Items.Select(p => new ItemViewModel
            {
                ItemId = p.ItemId,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
    }
}
