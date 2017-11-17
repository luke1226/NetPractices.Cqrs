namespace NetPractices.Cqrs
{
    public interface ICommandBus
    {
        void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
    }
}