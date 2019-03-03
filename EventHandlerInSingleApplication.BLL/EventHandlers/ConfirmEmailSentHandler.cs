using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL.EventHandlers
{
    public class ConfirmEmailSentHandler : IEventHandler<ShoppingCartSubmittedEvent>
    {
        public void Run(ShoppingCartSubmittedEvent obj)
        {
            Console.WriteLine("Confirm Email Sent.");
        }

        public Task RunAsync(ShoppingCartSubmittedEvent obj)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Confirm Email Sent.");
            });
        }
    }
}
