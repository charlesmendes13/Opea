using MediatR;

namespace Opea.Application.Commands
{
    public class UpdateClientCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public int CompanySizeId { get; private set; }

        public UpdateClientCommand(int id, string companyName, int companySizeId)
        {
            Id = id;
            CompanyName = companyName;
            CompanySizeId = companySizeId;
        }
    }
}
