using Microsoft.EntityFrameworkCore;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Commom;
using Opea.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opea.Infrastructure.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly OpeaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClientRepository(OpeaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Client
                .ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Client
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
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
