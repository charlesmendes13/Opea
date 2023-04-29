using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Domain.Events
{
    public class ClientRemovedEvent : INotification
    {
        public Client Client { get; }

        public ClientRemovedEvent(Client client)
        {
            Client = client;
        }
    }
}
