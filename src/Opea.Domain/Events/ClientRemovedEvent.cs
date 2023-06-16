using MediatR;

namespace Opea.Domain.Events
{
    public class ClientRemovedEvent : INotification
    {
        public int Id { get; private set; }

        public ClientRemovedEvent(int id)
        {
            Id = id;
        }
    }
}
