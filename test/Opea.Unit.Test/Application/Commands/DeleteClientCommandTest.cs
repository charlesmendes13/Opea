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
            client.Setup(x => x.Id).Returns(1);

            var deleteClientCommand = new Mock<DeleteClientCommand>(client.Object.Id);

            Assert.NotNull(deleteClientCommand.Object);
        }
    }
}
