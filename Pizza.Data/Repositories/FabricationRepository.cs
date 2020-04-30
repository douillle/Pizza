using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class FabricationRepository : Repository<Fabrication>, IFabricationRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public FabricationRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task AddFabrication(Fabrication entity)
        {
            await PizzaDbContext.Fabrications.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }
    }
}
