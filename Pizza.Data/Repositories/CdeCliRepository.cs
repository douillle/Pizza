using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class CdeCliRepository : Repository<CdeCli>, ICdeCliRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public CdeCliRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task CreateCommand(CdeCli entity)
        {
            await PizzaDbContext.CdeCli.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CdeCli>> GetAllCommands()
        {
            return await PizzaDbContext.CdeCli
                    .Include(cde => cde.Client).ThenInclude(c => c.Adresse).ThenInclude(a => a.Quartier)
                    .OrderByDescending(cde => cde.Date_Cde)
                    .ToListAsync();
        }

        public async Task<int?> GetLastCommandId()
        {
            var cde = await PizzaDbContext.CdeCli
                .OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();

            return cde?.Id;
        }
    }
}
