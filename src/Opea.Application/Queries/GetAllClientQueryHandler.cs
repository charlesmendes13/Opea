using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Exceptions;

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
            var clients = await _clientRepository.GetAllAsync();

            if (clients.Count() == 0)
                throw new DomainException(nameof(clients));

            return clients;
        }
    }
}
