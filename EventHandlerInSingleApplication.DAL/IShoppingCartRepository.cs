using EventHandlerInSingleApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public interface IShoppingCartRepository
    {
        void SubmitShoppingCart(string shoppingCartId);

        ShoppingCartViewModel GetShoppingCart(string shoppingCartId);
    }
}
