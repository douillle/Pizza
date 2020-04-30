using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Services
{
    public interface IPizzaService
    {
        Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas();
        Task<Catalogue_Pizza> GetPizzaById(int id);
    }
}
