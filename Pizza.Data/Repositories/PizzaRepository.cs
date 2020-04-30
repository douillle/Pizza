using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class PizzaRepository : Repository<Catalogue_Pizza>, IPizzaRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public PizzaRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas()
        {
            return await PizzaDbContext.Catalogue_Pizza
                .ToListAsync();
        }

        public async Task<Catalogue_Pizza> GetPizzaById(int id)
        {
            return await PizzaDbContext.Catalogue_Pizza
                .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
