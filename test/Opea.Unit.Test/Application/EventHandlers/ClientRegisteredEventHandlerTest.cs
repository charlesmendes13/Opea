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
            var client = new Mock<Client>(1, "Meta", 3);

            var notification = new Mock<ClientRegisteredEvent>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<ClientRegisteredEventHandler>();

            Assert.NotNull(handler.Object.Handle(notification.Object, new CancellationToken()));
        }
    }
}
