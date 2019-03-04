using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public static class DataStore
    {
        public static List<Order> Orders = new List<Order>();
        public static List<ShoppingCart> ShoppingCarts = new List<ShoppingCart>();

        public static List<Item> Items = new List<Item>()
        {
            new Item("IT_001", "XPS 15", 10000),
            new Item("IT_002", "Presicion 3530", 12000),
            new Item("IT_003", "XPS 13", 8000)
        };
    }
}
