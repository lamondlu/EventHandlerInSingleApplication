using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.BLL
{
    public interface IShoppingCartManager
    {
        string CreateShoppingCart();

        void AddItemToShoppingCart(string shoppingCartId, string itemId);

        void SubmitShoppingCart(string shoppingCartId);
    }
}
