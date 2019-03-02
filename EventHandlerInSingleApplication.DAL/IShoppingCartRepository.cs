using EventHandlerInSingleApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public interface IShoppingCartRepository
    {
        void SubmitShoppingCart(string shoppingCartId);

        string CreateShoppingCart();

        ShoppingCartViewModel GetShoppingCart(string shoppingCartId);

        void AddItemToShippingCart(string shoppingCartId, string itemId);
    }
}
