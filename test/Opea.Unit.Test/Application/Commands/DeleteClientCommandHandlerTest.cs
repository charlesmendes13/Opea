using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class DeleteClientCommandHandlerTest
    {
        [Fact]
        public async void DeleteClientCommandHandler()
        {
            var client = new Mock<Client>(1, "Meta", 3);
            client.Setup(x => x.Id).Returns(1);
            var cancellationToken = true;

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Delete(It.IsAny<Client>()));
            clientRepository.Setup(x => x.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(cancellationToken);

            var command = new Mock<DeleteClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);
            var handler = new Mock<DeleteClientCommandHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(command.Object, new CancellationToken());

            Assert.True(result);
        }
    }
}
