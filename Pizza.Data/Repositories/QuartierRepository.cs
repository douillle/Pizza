using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class QuartierRepository : Repository<Quartier>, IQuartierRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public QuartierRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Quartier>> GetAllDistricts()
        {
            return await PizzaDbContext.Quartier
                .ToListAsync();
        }
    }
}
