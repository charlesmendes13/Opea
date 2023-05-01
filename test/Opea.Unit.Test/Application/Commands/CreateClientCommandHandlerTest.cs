using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class CreateClientCommandHandlerTest
    {
        public async void CreateClientCommandHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.InsertAsync(It.IsAny<Client>()))
                .ReturnsAsync(client.Object);

            var command = new Mock<CreateClientCommand>(client.Object);
            var handler = new Mock<CreateClientCommandHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(command.Object, new CancellationToken());

            Assert.NotNull(result);
        }
    }
}
