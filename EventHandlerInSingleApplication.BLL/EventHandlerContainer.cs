using EventHandlerInSingleApplication.BLL.EventHandlers;
using EventHandlerInSingleApplication.BLL.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerInSingleApplication.BLL
{
    public class EventHandlerContainer
    {
        private static EventHandlerContainer _current = null;
        private Dictionary<string, List<IEventHandler<EventBase>>> _mappings = new Dictionary<string, List<IEventHandler<EventBase>>>();

        public void Subscribe<T>(IEventHandler<T> handler) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_mappings.ContainsKey(name))
            {
                _mappings.Add(name, new List<IEventHandler<EventBase>>());
            }

            _mappings[name].Add(handler);
        }

        public void Unsubscribe<T>(IEventHandler<T> handler) where T : EventBase
        {
            var name = typeof(T).Name;
            _mappings[name].Remove(handler);
        }

        public void Trigger<T>(T o) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_mappings.ContainsKey(name))
            {
                foreach (var handler in _mappings[name])
                {
                    handler.Run(o);
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
                    await handler.RunAsync(o);
                }
            }
        }

        public static EventHandlerContainer Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new EventHandlerContainer();
                }

                return _current;
            }
        }
    }
}
