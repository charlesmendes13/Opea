using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetAllCompanySizeQueryHandler : IRequestHandler<GetAllCompanySizeQuery, IEnumerable<CompanySize>>
    {
        public GetAllCompanySizeQueryHandler() { }

        public async Task<IEnumerable<CompanySize>> Handle(GetAllCompanySizeQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(CompanySize.GetAll<CompanySize>());
        }
    }
}
