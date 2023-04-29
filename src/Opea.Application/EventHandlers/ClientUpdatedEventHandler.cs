using MediatR;
using Opea.Domain.Events;

namespace Opea.Application.EventHandlers
{
    public class ClientUpdatedEventHandler
        : INotificationHandler<ClientUpdatedEvent>
    {
        public Task Handle(ClientUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
