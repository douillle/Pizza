using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class FacturationRepository : Repository<Fact_Cli_BonLiv>, IFacturationRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public FacturationRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task CreateFacturation(Fact_Cli_BonLiv entity)
        {
            await PizzaDbContext.Fact_Cli_BonLiv.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }

        public async Task<int?> GetLastFactureId()
        {
            var facture = await PizzaDbContext.Fact_Cli_BonLiv
                .OrderByDescending(f => f.Id)
                .FirstOrDefaultAsync();

            return facture?.Id;
        }

        public async Task<Fact_Cli_BonLiv> GetLastFacture()
        {
            return await PizzaDbContext.Fact_Cli_BonLiv
                .OrderByDescending(f => f.Id)
                .FirstOrDefaultAsync();
        }
    }
}
