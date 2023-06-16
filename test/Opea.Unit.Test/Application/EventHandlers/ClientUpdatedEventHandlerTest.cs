using Opea.Application.EventHandlers;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Unit.Test.Application.EventHandlers
{
    public class ClientUpdatedEventHandlerTest
    {
        [Fact]
        public void ClientUpdatedEventHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var notification = new Mock<ClientUpdatedEvent>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<ClientUpdatedEventHandler>();

            Assert.NotNull(handler.Object.Handle(notification.Object, new CancellationToken()));
        }
    }
}
