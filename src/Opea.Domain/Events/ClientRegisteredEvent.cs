using MediatR;

namespace Opea.Domain.Events
{
    public class ClientRegisteredEvent : INotification
    {
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public ClientRegisteredEvent(string companyName, int companySizeId)
        {
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
