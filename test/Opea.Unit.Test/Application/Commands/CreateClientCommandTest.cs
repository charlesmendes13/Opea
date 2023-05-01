using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class CreateClientCommandTest
    {
        [Fact]
        public void CreateClientCommand()
        {
            var client = new Mock<Client>("Google", 3);
            var createClientCommand = new Mock<CreateClientCommand>(client.Object);

            Assert.NotNull(createClientCommand.Object);
        }
    }
}
