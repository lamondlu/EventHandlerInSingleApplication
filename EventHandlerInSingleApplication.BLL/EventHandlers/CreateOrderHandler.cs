using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EventHandlerInSingleApplication.BLL.EventHandlers
{
    public class CreateOrderHandler : IEventHandler<ShoppingCartSubmittedEvent>
    {
        private IOrderManager _orderManager = null;

        public CreateOrderHandler(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public void Run(ShoppingCartSubmittedEvent obj)
        {
            _orderManager.CreateNewOrder(new Models.DTOs.CreateOrderDTO
            {
                Items = obj.Items.Select(p => new Models.DTOs.NewOrderItemDTO
                {
                    ItemId = p.ItemId,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            });
        }

        public Task RunAsync(ShoppingCartSubmittedEvent obj)
        {
            return Task.Run(() =>
            {
                Run(obj);
            });
        }
    }
}
