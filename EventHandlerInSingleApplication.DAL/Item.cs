using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public class Item
    {
        public Item(string itemId, string name, decimal price)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
        }

        public string ItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
