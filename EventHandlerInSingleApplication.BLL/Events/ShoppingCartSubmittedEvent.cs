using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.BLL.Events
{
    public class ShoppingCartSubmittedEvent : EventBase
    {
        public ShoppingCartSubmittedEvent()
        {
            Items = new List<ShoppingCartSubmittedItem>();
        }

        public List<ShoppingCartSubmittedItem> Items { get; set; }
    }

    public class ShoppingCartSubmittedItem
    {
        public string ItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}
