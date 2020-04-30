using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface ICdeCliRepository : IRepository<CdeCli>
    {
        Task<IEnumerable<CdeCli>> GetAllCommands();
        Task CreateCommand(CdeCli entity);
        Task<int?> GetLastCommandId();
    }
}
