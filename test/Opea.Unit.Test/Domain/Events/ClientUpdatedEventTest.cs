using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Domain.Events
{
    public class ClientUpdatedEventTest
    {
        [Fact]
        public void ClientUpdatedEvent()
        {
            var client = new Mock<Client>("Microsoft", 3);
            var clientUpdatedEvent = new ClientUpdatedEvent(client.Object);

            Assert.NotNull(clientUpdatedEvent);
        }
    }
}
