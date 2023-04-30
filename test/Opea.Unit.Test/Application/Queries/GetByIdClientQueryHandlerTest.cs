using Opea.Application.Queries;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetByIdClientQueryHandlerTest
    {
        [Fact]
        public async void GetByIdClientQueryHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(client.Object);

            var query = new GetByIdClientQuery()
            { 
                Id = 1
            };
            var handler = new Mock<GetByIdClientQueryHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(query, new CancellationToken());

            Assert.NotNull(result);
        }
    }
}
