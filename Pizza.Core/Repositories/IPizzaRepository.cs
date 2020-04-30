using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IPizzaRepository : IRepository<Catalogue_Pizza>
    {
        Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas();
        Task<Catalogue_Pizza> GetPizzaById(int id);
    }
}
