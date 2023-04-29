using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetByIdClientQuery : IRequest<Client>
    {
        public int Id { get; protected set; }
    }
}
