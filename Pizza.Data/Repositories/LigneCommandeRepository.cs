using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class LigneCommandeRepository : Repository<Ligne_Cde_Cli>, ILigneCommandeRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public LigneCommandeRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Ligne_Cde_Cli>> GetCommandLinesByCommandId(int id)
        {
            return await PizzaDbContext.Ligne_Cde_Cli
                .Include(m => m.Commande)
                .Include(m => m.Pizza)
                .Where(m => m.Num_Cde_Cli == id)
                .ToListAsync();
        }

        public async Task AddCommandLines(IEnumerable<Ligne_Cde_Cli> entities)
        {
            await PizzaDbContext.Ligne_Cde_Cli.AddRangeAsync(entities);
            await PizzaDbContext.SaveChangesAsync();
        }
    }
}
