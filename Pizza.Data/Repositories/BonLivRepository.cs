using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class BonLivRepository : Repository<BonLiv>, IBonLivRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public BonLivRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task CreateBonLiv(BonLiv entity)
        {
            await PizzaDbContext.BonLiv.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }

        public async Task<BonLiv> GetLastBonLiv()
        {
            return await PizzaDbContext.BonLiv
                .Include(b => b.CdeCli).ThenInclude(cde => cde.Client).ThenInclude(c => c.Adresse).ThenInclude(a => a.Quartier)
                .OrderByDescending(b => b.Id)
                .FirstOrDefaultAsync();
        }
    }
}
