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
            Status = OrderStatus.New;
        }

        public string OrderId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Paid,
        Shipped,
        Completed
    }
}
