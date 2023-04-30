using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Domain.AggragatesModel.ClientAggragate
{
    public class ClientTest
    {
        [Fact]
        public void Client()
        {
            var client = new Client("Google", 3);

            Assert.NotNull(client);
        }
    }
}
