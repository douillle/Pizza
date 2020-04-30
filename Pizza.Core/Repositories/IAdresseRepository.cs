using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IAdresseRepository : IRepository<Adresses>
    {
        Task<Adresses> GetAdresseByText(string adresse);
        Task CreateAddress(Adresses entity);
    }
}
