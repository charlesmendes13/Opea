using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class DeleteClientCommandTest
    {
        [Fact]
        public void DeleteClientCommand()
        {
            var client = new Mock<Client>("Google", 3);
            var deleteClientCommand = new Mock<DeleteClientCommand>(client.Object);

            Assert.NotNull(deleteClientCommand.Object);
        }
    }
}
