using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Domain.Events
{
    public class ClientRegisteredEventTest
    {
        [Fact]
        public void ClientRegisteredEvent()
        {
            var client = new Mock<Client>("Microsoft", 3);
            var clientRegisteredEvent = new ClientRegisteredEvent(client.Object.CompanyName, client.Object.CompanySizeId);

            Assert.NotNull(clientRegisteredEvent);
        }
    }
}
