using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Domain.Events
{
    public class ClientRegisteredEvent : INotification
    {
        public Client Client { get; }

        public ClientRegisteredEvent(Client client)
        {
            Client = client;
        }
    }
}
