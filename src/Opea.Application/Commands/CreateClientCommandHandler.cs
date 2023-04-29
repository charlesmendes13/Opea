using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.InsertAsync(request.Client);

            if (client != null)
                client.AddDomainEvent(new ClientRegisteredEvent(client));

            await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return client;
        }
    }
}
