using Opea.Domain.Commom;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Client InsertAsync(Client client);
        Client UpdateAsync(Client client);
        Client DeleteAsync(Client client);
    }
}
