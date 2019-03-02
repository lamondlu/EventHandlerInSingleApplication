using EventHandlerInSingleApplication.BLL.EventHandlers;
using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL
{
    public class EventHandlerContainer
    {
        private IServiceProvider _serviceProvider = null;
        private Dictionary<string, List<Type>> _mappings = new Dictionary<string, List<Type>>();

        public EventHandlerContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Subscribe<T>(Type t)
        {
            var name = typeof(T).Name;

            if (!_mappings.ContainsKey(name))
            {
                _mappings.Add(name, new List<Type> { });
            }

            _mappings[name].Add(t);
        }

        public void Unsubscribe<T>(Type t) where T : EventBase
        {
            var name = typeof(T).Name;
            _mappings[name].Remove(t);

            if (_mappings[name].Count == 0)
            {
                _mappings.Remove(name);
            }
        }

        public void Trigger<T>(T o) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_mappings.ContainsKey(name))
            {
                foreach (var handler in _mappings[name])
                {
                    var service = (IEventHandler<T>)_serviceProvider.GetService(handler);

                    service.Run(o);
                }
            }
        }

        public async Task TriggerAsync<T>(T o) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_mappings.ContainsKey(name))
            {
                foreach (var handler in _mappings[name])
                {
                    var service = (IEventHandler<T>)_serviceProvider.GetService(handler);

                    await service.RunAsync(o);
                }
            }
        }
    }
}
