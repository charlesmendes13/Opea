using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetAllCompanySizeQuery : IRequest<IEnumerable<CompanySize>>
    {
        public GetAllCompanySizeQuery() { }
    }
}
