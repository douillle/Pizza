using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Services
{
    public interface IQuartierService
    {
        Task<IEnumerable<Quartier>> GetAllDistricts();
    }
}
