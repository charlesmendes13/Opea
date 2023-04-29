using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Domain.Events
{
    public class ClientUpdatedEvent : INotification
    {
        public Client Client { get; }

        public ClientUpdatedEvent(Client client)
        {
            Client = client;
        }
    }
}
