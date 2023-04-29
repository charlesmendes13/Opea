using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.UpdateAsync(request.Client);

            if (client != null)
                client.AddDomainEvent(new ClientUpdatedEvent(client));

            await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return client;
        }
    }
}
