using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, IEnumerable<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetAllAsync();          
        }
    }
}
