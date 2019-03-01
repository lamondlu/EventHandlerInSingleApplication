using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.Models.DTOs
{
    public class AddItemToShoppingCartDTO
    {
        public string ShoppingCartId { get; set; }

        public string ItemId { get; set; }
    }
}
