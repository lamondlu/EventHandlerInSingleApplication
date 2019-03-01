using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public class OrderItem
    {
        public OrderItem(string itemName, string itemId, decimal itemPrice)
        {
            OrderItemId = $"ORDER_ITEM_{DateTime.Now.Ticks}";
            ItemName = itemName;
            ItemId = itemId;
            ItemPrice = itemPrice;
        }

        public string OrderItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemId { get; set; }

        public decimal ItemPrice { get; set; }
    }
}
