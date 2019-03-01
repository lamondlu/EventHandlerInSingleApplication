using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public class Order
    {
        public Order(List<OrderItem> OrderItems)
        {
            OrderId = $"ORDER_{DateTime.Now.Ticks}";
        }

        public string OrderId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
