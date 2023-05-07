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
            request.Client.AddDomainEvent(new ClientRemovedEvent(request.Client));

            _clientRepository.Delete(request.Client);    

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
