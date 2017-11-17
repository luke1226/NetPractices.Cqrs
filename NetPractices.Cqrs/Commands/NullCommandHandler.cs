namespace NetPractices.Cqrs
{
    class NullCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public void Handle(TCommand command)
        {

        }
    }
}