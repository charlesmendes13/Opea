using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Commands
{
    public class UpdateClientCommand : IRequest<Client>
    {
        public Client Client { get; private set; }

        public UpdateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
