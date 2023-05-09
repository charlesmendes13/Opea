using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class DeleteClientCommandTest
    {
        [Fact]
        public void DeleteClientCommand()
        {
            var client = new Mock<Client>(1, "Google", 3);
            var deleteClientCommand = new Mock<DeleteClientCommand>(client.Object.Id, client.Object.CompanyName, client.Object.CompanySizeId);

            Assert.NotNull(deleteClientCommand.Object);
        }
    }
}
