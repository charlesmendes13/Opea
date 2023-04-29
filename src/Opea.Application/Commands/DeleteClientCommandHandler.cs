using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Client>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.DeleteAsync(request.Client);

            if (client != null)
                client.AddDomainEvent(new ClientRemovedEvent(client));

            await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return client;
        }
    }
}
