using System;
using System.Collections.Generic;
using System.Text;
using EventHandlerInSingleApplication.DAL;
using EventHandlerInSingleApplication.Models.DTOs;
using Newtonsoft.Json;

namespace EventHandlerInSingleApplication.BLL
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string CreateNewOrder(CreateOrderDTO dto)
        {
            var orderId = _orderRepository.CreatOrder(dto);

            Console.WriteLine($"One order created: {JsonConvert.SerializeObject(dto)}");

            return orderId;
        }
    }
}
