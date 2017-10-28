using System.Collections.Generic;

namespace NetPractices.Cqrs
{
    public interface IEventHandlersRegistry
    {
        void Register<TEvent>(IEventHandler<TEvent> handler)
            where TEvent : IEvent;

        IEnumerable<IEventHandler<TEvent>> Get<TEvent>()
            where TEvent : IEvent;
    }
}