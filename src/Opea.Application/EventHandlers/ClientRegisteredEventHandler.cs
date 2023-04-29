using MediatR;
using Opea.Domain.Events;

namespace Opea.Application.EventHandlers
{
    public class ClientRegisteredEventHandler
        : INotificationHandler<ClientRegisteredEvent>
    {
        public Task Handle(ClientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
