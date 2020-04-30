using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IQuartierRepository : IRepository<Quartier>
    {
        Task<IEnumerable<Quartier>> GetAllDistricts();
    }
}
