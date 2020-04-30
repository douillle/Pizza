using Pizza.Core.Models;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IFabricationRepository : IRepository<Fabrication>
    {
        Task AddFabrication(Fabrication entity);
    }
}
