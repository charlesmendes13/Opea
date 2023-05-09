using MediatR;

namespace Opea.Domain.Events
{
    public class ClientUpdatedEvent : INotification
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public ClientUpdatedEvent(int id, string companyName, int companySizeId)
        {
            Id = id;
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
