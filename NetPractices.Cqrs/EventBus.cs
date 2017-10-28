namespace NetPractices.Cqrs
{
    public class EventBus : IEventBus
    {
        private readonly IEventHandlersRegistry _eventHandlersRegistry;

        public EventBus(IEventHandlersRegistry eventHandlersRegistry)
        {
            _eventHandlersRegistry = eventHandlersRegistry;
        }

        public void Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            var handlers = _eventHandlersRegistry.Get<TEvent>();

            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);
            }
        }
    }
}
