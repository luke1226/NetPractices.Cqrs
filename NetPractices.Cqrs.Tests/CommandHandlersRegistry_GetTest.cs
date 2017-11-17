using System.Linq;
using NSubstitute;
using Xunit;

namespace NetPractices.Cqrs.Tests
{
    public class CommandHandlersRegistry_GetTest
    {
        [Fact]
        public void ShouldReturnProperHandler()
        {
            //Arrange
            var registry = new CommandHandlersRegistry();

            registry.Register(CreateHandler<TestCommand>());
            registry.Register(CreateHandler<TestCommand>());
            registry.Register(CreateHandler<TestCommand2>());


            //Act
            var handler = registry.Get<TestCommand>();


            //Assert
            Assert.NotNull(handler);
            Assert.True(handler is ICommandHandler<TestCommand>);
            Assert.False(handler is NullCommandHandler<TestCommand>);
        }

        [Fact]
        public void ShouldReturnNullHandler()
        {
            //Arrange
            var registry = new CommandHandlersRegistry();

            registry.Register(CreateHandler<TestCommand>());
            registry.Register(CreateHandler<TestCommand>());
            registry.Register(CreateHandler<TestCommand2>());


            //Act
            var handler = registry.Get<TestCommand3>();


            //Assert
            Assert.NotNull(handler);
            Assert.True(handler is ICommandHandler<TestCommand3>);
            Assert.True(handler is NullCommandHandler<TestCommand3>);
        }


        private ICommandHandler<T> CreateHandler<T>()
            where T : ICommand
        {
            var eventHandler = Substitute.For<ICommandHandler<T>>();
            return eventHandler;
        }
    }

    class TestCommand : ICommand { }

    class TestCommand2 : ICommand { }

    class TestCommand3 : ICommand { }
}
