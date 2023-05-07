using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            request.Client.AddDomainEvent(new ClientUpdatedEvent(request.Client));

            _clientRepository.Update(request.Client);            

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); 
        }
    }
}
