using Opea.Application.Queries;
using Opea.Domain.AggregatesModel.ClientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opea.Unit.Test.Application.Queries
{
    public class GetAllClientQueryHandlerTest
    {
        [Fact]
        public async void GetAllClientQueryHandler()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clients = new List<Client>()
            {
                client.Object
            };

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(clients);

            var query = new GetAllClientQuery();
            var handler = new Mock<GetAllClientQueryHandler>(clientRepository.Object);

            var result = await handler.Object.Handle(query, new CancellationToken());

            Assert.NotNull(result);
        }
    }
}
