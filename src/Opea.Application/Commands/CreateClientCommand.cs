using MediatR;

namespace Opea.Application.Commands
{
    public class CreateClientCommand : IRequest<bool>
    {
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public CreateClientCommand(string companyName, int companySizeId)
        {
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
