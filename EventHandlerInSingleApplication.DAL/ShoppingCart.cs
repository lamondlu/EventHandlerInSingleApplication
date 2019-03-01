using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartId = $"ShoppingCart_{DateTime.Now.Ticks}";
            Items = new List<Item>();
        }

        public string ShoppingCartId { get; set; }

        public List<Item> Items { get; set; }
    }
}
