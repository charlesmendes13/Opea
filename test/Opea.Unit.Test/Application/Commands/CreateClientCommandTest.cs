using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class CreateClientCommandTest
    {
        [Fact]
        public void CreateClientCommand()
        {
            var client = new Mock<Client>(1, "Google", 3);
            var createClientCommand = new Mock<CreateClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);

            Assert.NotNull(createClientCommand.Object);
        }
    }
}
