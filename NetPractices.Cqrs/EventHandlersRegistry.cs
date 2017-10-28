using System;
using System.Collections.Generic;
using System.Linq;

namespace NetPractices.Cqrs
{
    public class EventHandlersRegistry : IEventHandlersRegistry
    {
        private readonly Dictionary<Type, List<IEventHandler>> _handlers;

        public EventHandlersRegistry()
        {
            _handlers = new Dictionary<Type, List<IEventHandler>>();
        }

        public void Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_handlers.ContainsKey(eventType))
                _handlers[eventType].Add(handler);
            else
                _handlers.Add(eventType, new List<IEventHandler>() {handler});
        }

        public IEnumerable<IEventHandler<TEvent>> Get<TEvent>() where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_handlers.ContainsKey(eventType))
                return _handlers[eventType].Cast<IEventHandler<TEvent>>();
            else
                return new List<IEventHandler<TEvent>>();
        }
    }
}