using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Items = new List<ShoppingCartItemViewModel>();
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItemViewModel> Items { get; set; }
    }
}
