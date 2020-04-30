using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public ClientRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await PizzaDbContext.Client
                    .Include(c => c.Adresse).ThenInclude(a => a.Quartier)
                    .ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await PizzaDbContext.Client
                .Include(m => m.Adresse).ThenInclude(a => a.Quartier)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddClient(Client entity)
        {
            await PizzaDbContext.Client.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }

        public async Task<int?> GetClientIdByName(string name)
        {
            var client = await PizzaDbContext.Client
                            .SingleOrDefaultAsync(m => m.Nom_Cli == name);

            return client?.Id;
        }
    }
}
