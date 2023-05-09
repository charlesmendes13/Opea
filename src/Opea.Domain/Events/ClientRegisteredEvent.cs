using MediatR;

namespace Opea.Domain.Events
{
    public class ClientRegisteredEvent : INotification
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public ClientRegisteredEvent(int id, string companyName, int companySizeId)
        {
            Id = id;
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
