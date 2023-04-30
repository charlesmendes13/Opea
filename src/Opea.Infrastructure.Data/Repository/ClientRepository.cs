using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Commom;
using Opea.Infrastructure.Data.Context;

namespace Opea.Infrastructure.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly OpeaContext _context;
        public IUnitOfWork UnitOfWork => _context;
        private string _connectionString = string.Empty;

        public ClientRepository(OpeaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection
                .QueryAsync<Client>(@"SELECT * FROM Client");
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection
                .QueryFirstOrDefaultAsync<Client>(@"SELECT * FROM Client WHERE Id = @id", new { id });                
        }

        public async Task<Client> InsertAsync(Client client)
        {
            await _context.Client.AddAsync(client);

            return client;
        }

        public Client UpdateAsync(Client client)
        {
            _context.Client.Update(client);

            return client;
        }

        public Client DeleteAsync(Client client)
        {
            _context.Client.Remove(client);

            return client;
        }        
    }
}
