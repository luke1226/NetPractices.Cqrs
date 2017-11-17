namespace NetPractices.Cqrs
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}