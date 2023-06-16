using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class UpdateClientCommandHandlerTest
    {
        [Fact]
        public async void UpdateClientCommandHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);
            var cancellationToken = true;

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(client.Object);
            clientRepository.Setup(x => x.Update(It.IsAny<Client>()));               
            clientRepository.Setup(x => x.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(cancellationToken);

            var command = new Mock<UpdateClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<UpdateClientCommandHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(command.Object, new CancellationToken());

            Assert.True(result);
        }
    }
}
