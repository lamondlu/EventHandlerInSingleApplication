using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL.EventHandlers
{
    public class ShoppingCartSubmittedEventHandler : IEventHandler<ShoppingCartSubmittedEvent>
    {
        private IOrderManager _orderManager = null;

        public ShoppingCartSubmittedEventHandler(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public void Run(EventBase obj)
        {
            Console.WriteLine("Hello World");
        }

        public Task RunAsync(EventBase obj)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Hello World");
            });
        }
    }
}
