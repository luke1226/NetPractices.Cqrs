namespace NetPractices.Cqrs
{
    public interface ICommandHandlersRegistry
    {
        void Register<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;

        ICommandHandler<TCommand> Get<TCommand>() where TCommand : ICommand;
    }
}