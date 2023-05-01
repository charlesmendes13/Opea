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
            var updateClientCommand = new Mock<UpdateClientCommand>(client.Object);

            Assert.NotNull(updateClientCommand.Object);
        }
    }
}
