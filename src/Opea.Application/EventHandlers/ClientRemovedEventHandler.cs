using MediatR;
using Opea.Domain.Events;

namespace Opea.Application.EventHandlers
{
    public class ClientRemovedEventHandler
        : INotificationHandler<ClientRemovedEvent>
    {
        public Task Handle(ClientRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
