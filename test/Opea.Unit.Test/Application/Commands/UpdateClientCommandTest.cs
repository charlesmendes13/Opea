using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class UpdateClientCommandTest
    {
        [Fact]
        public void UpdateClientCommand()
        {
            var client = new Mock<Client>("Google", 3);
            client.Setup(x => x.Id).Returns(1);

            var updateClientCommand = new Mock<UpdateClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);

            Assert.NotNull(updateClientCommand.Object);
        }
    }
}
