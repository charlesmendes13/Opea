using Opea.Application.Queries;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetAllClientQueryHandlerTest
    {
        [Fact]
        public async void GetAllClientQueryHandler()
        {
            var clients = new List<Client>()
            {
                new Mock<Client>(1, "Meta", 3).Object,
                new Mock<Client>(2, "Google", 3).Object,
                new Mock<Client>(3, "Microsoft", 3).Object
            };

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(clients);

            var query = new Mock<GetAllClientQuery>();
            var handler = new Mock<GetAllClientQueryHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(query.Object, new CancellationToken());

            Assert.NotNull(result);
        }
    }
}
