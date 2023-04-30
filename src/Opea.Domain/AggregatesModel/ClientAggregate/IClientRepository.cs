using Opea.Domain.Commom;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> InsertAsync(Client client);
        Client Update(Client client);
        Client Delete(Client client);
    }
}
