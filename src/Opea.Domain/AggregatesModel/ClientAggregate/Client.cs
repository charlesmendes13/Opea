using Opea.Domain.Commom;
using Opea.Domain.Exceptions;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public class Client : Entity, IAggregateRoot
    {
        public string CompanyName { get; private set; }

        private int _companySizeId;
        public CompanySize CompanySize { get; private set; }

        protected Client() { }

        public Client(string companyName, int companySizeId)
        {
            CompanyName = !string.IsNullOrWhiteSpace(companyName) ? companyName : throw new DomainException(nameof(companyName));
            companySizeId = _companySizeId;
        }
    }
}
