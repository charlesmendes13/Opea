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
            var client = new Client(request.Id, request.CompanyName, request.CompanySizeId);

            client.AddDomainEvent(new ClientRegisteredEvent(client.Id, client.CompanyName, client.CompanySizeId));
            await _clientRepository.InsertAsync(client);           

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); ;
        }
    }
}
