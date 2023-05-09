using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Domain.AggragatesModel.ClientAggragate
{
    public class ClientTest
    {
        [Fact]
        public void Client()
        {
            var client = new Mock<Client>(1, "Google", 3);

            Assert.NotNull(client);
        }
    }
}
