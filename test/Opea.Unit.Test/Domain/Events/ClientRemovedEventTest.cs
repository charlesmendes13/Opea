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
            client.Setup(x => x.Id).Returns(1);

            var clientRemovedEvent = new ClientRemovedEvent(client.Object.Id);

            Assert.NotNull(clientRemovedEvent);
        }
    }
}
