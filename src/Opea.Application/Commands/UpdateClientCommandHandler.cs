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
            var client = new Client(request.Id, request.CompanyName, request.CompanySizeId);

            client.AddDomainEvent(new ClientUpdatedEvent(client.Id, client.CompanyName, client.CompanySizeId));
            _clientRepository.Update(client);            

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); 
        }
    }
}
