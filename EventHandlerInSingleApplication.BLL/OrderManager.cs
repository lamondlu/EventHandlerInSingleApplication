using System;
using System.Collections.Generic;
using System.Text;
using EventHandlerInSingleApplication.Models.DTOs;
using Newtonsoft.Json;

namespace EventHandlerInSingleApplication.BLL
{
    public class OrderManager : IOrderManager
    {
        public string CreateNewOrder(CreateOrderDTO dto)
        {
            Console.WriteLine($"One order created: {JsonConvert.SerializeObject(dto)}");

            return string.Empty;
        }
    }
}
