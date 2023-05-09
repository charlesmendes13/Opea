using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class CreateClientCommandHandlerTest
    {
        [Fact]
        public async void CreateClientCommandHandler()
        {
            var client = new Mock<Client>(1, "Meta", 3);
            var cancellationToken = true;

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.InsertAsync(It.IsAny<Client>()));
            clientRepository.Setup(x => x.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(cancellationToken);

            var command = new Mock<CreateClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<CreateClientCommandHandler>(clientRepository.Object);            

            var result = await handler.Object.Handle(command.Object, new CancellationToken());

            Assert.True(result);
        }
    }
}
