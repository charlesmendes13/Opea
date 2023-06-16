using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Exceptions;

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
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client is null)
                throw new DomainException(nameof(client));

            client.Update(request.Id, request.CompanyName, request.CompanySizeId);

            _clientRepository.Update(client);            

            return await _clientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); 
        }
    }
}
