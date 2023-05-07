using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;

namespace Opea.Application.Commands
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            request.Client.AddDomainEvent(new ClientRegisteredEvent(request.Client));

            await _clientRepository.InsertAsync(request.Client);           

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); ;
        }
    }
}
