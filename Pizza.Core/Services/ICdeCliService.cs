using Pizza.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Core.Services
{
    public interface ICdeCliService
    {
        Task CreateCommand(CdeCli command);
        Task<IEnumerable<CdeCli>> GetAllCommands();
        Task<int?> GetLastCommandId();

        Task<IEnumerable<Ligne_Cde_Cli>> GetCommandLinesByCommandId(int id);
        Task AddCommandLines(IEnumerable<Ligne_Cde_Cli> lignes);

        Task AddFabrication(Fabrication pizza);

        Task CreateBonLiv(BonLiv bonLiv);

        Task CreateFacture(Fact_Cli_BonLiv facture);
        Task<int?> GetLastFactureId();
        Task<BonLiv> GetLastBonLiv();
        Task<Fact_Cli_BonLiv> GetLastFacture();
    }
}
