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
            var client = new Mock<Client>(1, "Meta", 3);

            var notification = new Mock<ClientRemovedEvent>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<ClientRemovedEventHandler>();

            Assert.NotNull(handler.Object.Handle(notification.Object, new CancellationToken()));
        }
    }
}
