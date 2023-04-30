using Opea.Application.EventHandlers;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Application.EventHandlers
{
    public class ClientRegisteredEventHandlerTest
    {
        [Fact]
        public void ClientRegisteredEventHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var notification = new ClientRegisteredEvent(client.Object);
            var handler = new Mock<ClientRegisteredEventHandler>();

            Assert.NotNull(handler.Object.Handle(notification, new CancellationToken()));
        }
    }
}
