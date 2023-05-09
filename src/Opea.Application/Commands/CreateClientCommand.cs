using MediatR;

namespace Opea.Application.Commands
{
    public class CreateClientCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public CreateClientCommand(int id, string companyName, int companySizeId)
        {
            Id = id;
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
