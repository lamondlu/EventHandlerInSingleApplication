using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL.EventHandlers
{
    public interface IEventHandler<in T> where T : EventBase
    {
        void Run(T obj);

        Task RunAsync(T obj);
    }
}
