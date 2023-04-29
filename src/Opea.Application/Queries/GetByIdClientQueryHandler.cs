using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Queries
{
    public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, Client>
    {
        private readonly IClientRepository _clientRepository;

        public GetByIdClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetByIdAsync(request.Id);
        }
    }
}
