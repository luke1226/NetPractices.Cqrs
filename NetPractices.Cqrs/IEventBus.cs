namespace NetPractices.Cqrs
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}