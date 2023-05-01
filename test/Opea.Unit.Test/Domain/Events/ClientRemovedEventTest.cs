using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Domain.Events
{
    public class ClientRemovedEventTest
    {
        [Fact]
        public void ClientRemovedEvent()
        {
            var client = new Mock<Client>("Microsoft", 3);
            var clientRemovedEvent = new ClientRemovedEvent(client.Object);

            Assert.NotNull(clientRemovedEvent);
        }
    }
}
