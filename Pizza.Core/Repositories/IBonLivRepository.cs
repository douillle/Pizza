using Pizza.Core.Models;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IBonLivRepository : IRepository<BonLiv>
    {
        Task CreateBonLiv(BonLiv entity);
        Task<BonLiv> GetLastBonLiv();
    }
}
