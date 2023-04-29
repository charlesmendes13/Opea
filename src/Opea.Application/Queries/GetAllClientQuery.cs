using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetAllClientQuery : IRequest<IEnumerable<Client>>
    {
    }
}
