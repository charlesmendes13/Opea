using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Domain.Events
{
    public class ClientRemovedEventTest
    {
        [Fact]
        public void ClientRemovedEvent()
        {
            var client = new Mock<Client>(1, "Microsoft", 3);
            var clientRemovedEvent = new ClientRemovedEvent(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);

            Assert.NotNull(clientRemovedEvent);
        }
    }
}
