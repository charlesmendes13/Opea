using Opea.Application.Commands;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Unit.Test.Application.Commands
{
    public class CreateClientCommandTest
    {
        [Fact]
        public void CreateClientCommand()
        {
            var client = new Client("Google", 3);

            var createClientCommand = new CreateClientCommand()
            {
                Client = client
            };

            Assert.NotNull(createClientCommand);
        }
    }
}
