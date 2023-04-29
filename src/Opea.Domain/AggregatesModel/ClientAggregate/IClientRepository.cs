using Opea.Domain.Commom;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> InsertAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<Client> DeleteAsync(Client client);
    }
}
