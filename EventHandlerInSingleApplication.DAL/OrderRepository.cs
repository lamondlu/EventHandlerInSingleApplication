using EventHandlerInSingleApplication.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EventHandlerInSingleApplication.DAL
{
    public class OrderRepository : IOrderRepository
    {
        public string CreatOrder(CreateOrderDTO dto)
        {
            Order order;

            if (dto.Items != null && dto.Items.Count > 0)
            {
                order = new Order(dto.Items
                    .Select(p =>
                        new OrderItem(p.Name, p.ItemId, p.Price))
                    .ToList());
            }
            else
            {
                order = new Order(new List<OrderItem>());
            }

            DataStore.Orders.Add(order);

            return order.OrderId;
        }
    }
}
