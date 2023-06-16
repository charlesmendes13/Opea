using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Exceptions;

namespace Opea.Application.Queries
{
    public class GetAllCompanySizeQueryHandler : IRequestHandler<GetAllCompanySizeQuery, IEnumerable<CompanySize>>
    {
        public GetAllCompanySizeQueryHandler() { }

        public async Task<IEnumerable<CompanySize>> Handle(GetAllCompanySizeQuery request, CancellationToken cancellationToken)
        {
            var companySizes = await Task.FromResult(CompanySize.GetAll<CompanySize>());

            if (companySizes.Count() == 0)
                throw new DomainException(nameof(companySizes));

            return companySizes;
        }
    }
}
