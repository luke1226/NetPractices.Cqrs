using System.Linq;
using NSubstitute;
using Xunit;

namespace NetPractices.Cqrs.Tests
{
    public class EventHandlersRegistry_GetTest
    {
        [Fact]
        public void ShouldReturnProperHandlers()
        {
            //Arrange
            var registry = new EventHandlersRegistry();

            registry.Register(CreateHandler<TestEvent>());
            registry.Register(CreateHandler<TestEvent>());
            registry.Register(CreateHandler<TestEvent2>());


            //Act
            var handlers = registry.Get<TestEvent>().ToList();


            //Assert
            Assert.Equal(2, handlers.Count);
        }

        [Fact]
        public void ShouldReturnEmptyHandlersList()
        {
            //Arrange
            var registry = new EventHandlersRegistry();

            registry.Register(CreateHandler<TestEvent>());
            registry.Register(CreateHandler<TestEvent>());
            registry.Register(CreateHandler<TestEvent2>());


            //Act
            var handlers = registry.Get<TestEvent3>().ToList();


            //Assert
            Assert.Empty(handlers);
        }


        private IEventHandler<T> CreateHandler<T>()
            where T : IEvent
        {
            var eventHandler = Substitute.For<IEventHandler<T>>();
            return eventHandler;
        }
    }

    class TestEvent : IEvent { }

    class TestEvent2 : IEvent { }

    class TestEvent3 : IEvent { }
}
