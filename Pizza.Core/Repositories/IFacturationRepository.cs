using Pizza.Core.Models;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IFacturationRepository : IRepository<Fact_Cli_BonLiv>
    {
        Task CreateFacturation(Fact_Cli_BonLiv entity);
        Task<int?> GetLastFactureId();
        Task<Fact_Cli_BonLiv> GetLastFacture();
    }
}
