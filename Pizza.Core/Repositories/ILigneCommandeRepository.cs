using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface ILigneCommandeRepository : IRepository<Ligne_Cde_Cli>
    {
        Task<IEnumerable<Ligne_Cde_Cli>> GetCommandLinesByCommandId(int id);
        Task AddCommandLines(IEnumerable<Ligne_Cde_Cli> entities);
    }
}
