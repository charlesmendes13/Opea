using Opea.Application.EventHandlers;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Application.EventHandlers
{
    public class ClientRemovedEventHandlerTest
    {
        [Fact]
        public void ClientRemovedEventHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var notification = new ClientRemovedEvent(client.Object);
            var handler = new Mock<ClientRemovedEventHandler>();

            Assert.NotNull(handler.Object.Handle(notification, new CancellationToken()));
        }
    }
}
