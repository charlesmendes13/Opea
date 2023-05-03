using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Commands
{
    public class CreateClientCommand : IRequest<bool>
    {
        public Client Client { get; private set; }

        public CreateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
