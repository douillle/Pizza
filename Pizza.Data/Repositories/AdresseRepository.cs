using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Core.Repositories;
using System.Threading.Tasks;

namespace Pizza.Data.Repositories
{
    public class AdresseRepository : Repository<Adresses>, IAdresseRepository
    {
        private PizzaDbContext PizzaDbContext
        {
            get { return Context as PizzaDbContext; }
        }

        public AdresseRepository(PizzaDbContext context)
            : base(context)
        { }

        public async Task<Adresses> GetAdresseByText(string adresse)
        {
            return await PizzaDbContext.Adresses
                        .Include(a => a.Quartier)
                        .SingleOrDefaultAsync(m => m.Adresse == adresse);
        }

        public async Task CreateAddress(Adresses entity)
        {
            await PizzaDbContext.Adresses.AddAsync(entity);
            await PizzaDbContext.SaveChangesAsync();
        }
    }
}
