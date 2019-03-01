using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL.EventHandlers
{
    public interface IEventHandler<out T> where T : EventBase
    {
        void Run(EventBase obj);

        Task RunAsync(EventBase obj);
    }
}
