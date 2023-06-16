using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Exceptions;

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
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client is null)
                throw new KeyNotFoundException(nameof(client));

            return client;
        }
    }
}
