namespace NetPractices.Cqrs
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlersRegistry _commandHandlersRegistry;

        public CommandBus(ICommandHandlersRegistry commandHandlersRegistry)
        {
            _commandHandlersRegistry = commandHandlersRegistry;
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            throw new System.NotImplementedException();
        }
    }
}