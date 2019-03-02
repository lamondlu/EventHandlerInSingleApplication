using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.Models.DTOs
{
    public class CreateOrderDTO
    {
        public CreateOrderDTO()
        {
            Items = new List<NewOrderItemDTO>();
        }

        public List<NewOrderItemDTO> Items { get; set; }
    }

    public class NewOrderItemDTO
    {
        public string ItemId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }
}
