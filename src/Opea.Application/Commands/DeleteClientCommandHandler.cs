using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Id, request.CompanyName, request.CompanySizeId);

            client.AddDomainEvent(new ClientRemovedEvent(client.Id, client.CompanyName, client.CompanySizeId));
            _clientRepository.Delete(client);    

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
