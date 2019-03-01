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
        private Dictionary<string, List<string>> _mappings = new Dictionary<string, List<string>>();

        public EventHandlerContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Subscribe<T>(Type t)
        {
            var name = typeof(T).Name;

            if (!_mappings.ContainsKey(name))
            {
                _mappings.Add(name, new List<string> { });
            }

            _mappings[name].Add(t.FullName);
        }

        public void Unsubscribe<T>(Type t) where T : EventBase
        {
            var name = typeof(T).Name;
            _mappings[name].Remove(t.FullName);

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
                    var service = (IEventHandler<T>)_serviceProvider.GetService(Assembly.GetExecutingAssembly().GetType(handler));

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
                    var service = (IEventHandler<T>)_serviceProvider.GetService(Assembly.GetExecutingAssembly().GetType(handler));

                    await service.RunAsync(o);
                }
            }
        }
    }
}
