using MediatR;

namespace Opea.Domain.Events
{
    public class ClientRemovedEvent : INotification
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public ClientRemovedEvent(int id, string companyName, int companySizeId)
        {
            Id = id;
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
