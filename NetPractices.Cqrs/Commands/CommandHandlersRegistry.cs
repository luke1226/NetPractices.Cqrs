using System;
using System.Collections.Generic;

namespace NetPractices.Cqrs
{
    public class CommandHandlersRegistry : ICommandHandlersRegistry
    {
        private readonly Dictionary<Type, ICommandHandler> _handlers;

        public CommandHandlersRegistry()
        {
            _handlers = new Dictionary<Type, ICommandHandler>();
        }

        public void Register<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            var commandType = typeof(TCommand);
            if (_handlers.ContainsKey(commandType))
                return;

            _handlers.Add(commandType, handler);
        }

        public ICommandHandler<TCommand> Get<TCommand>() where TCommand : ICommand
        {
            var handlerType = typeof(TCommand);
            if (_handlers.ContainsKey(handlerType))
                return (ICommandHandler<TCommand>)_handlers[handlerType];
            else
                return new NullCommandHandler<TCommand>();
        }
    }
}