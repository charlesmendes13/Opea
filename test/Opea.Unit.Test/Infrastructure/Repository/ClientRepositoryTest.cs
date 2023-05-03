using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Infrastructure.Repository
{
    public class ClientRepositoryTest
    {
        [Fact]
        public async void GetAllAsync()
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

            var result = await clientRepository.Object.GetAllAsync();

            Assert.NotNull(result); 
        }

        [Fact]
        public async void GetByIdAsync()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(client.Object);

            var result = await clientRepository.Object.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async void InsertAsync()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.InsertAsync(It.IsAny<Client>()));

            await clientRepository.Object.InsertAsync(client.Object);
        }

        [Fact]
        public void Update()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Update(It.IsAny<Client>()));

            clientRepository.Object.Update(client.Object);
        }

        [Fact]
        public void Delete()
        {
            var client = new Mock<Client>("Meta", 3);
            client.Setup(x => x.Id).Returns(1);

            var clientRepository = new Mock<IClientRepository>();
            clientRepository.Setup(x => x.Delete(It.IsAny<Client>()));

            clientRepository.Object.Delete(client.Object);
        }
    }
}
