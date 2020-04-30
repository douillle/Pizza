using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class CdeCliService : ICdeCliService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CdeCliService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCommandLines(IEnumerable<Ligne_Cde_Cli> lignes)
        {
            await _unitOfWork.CommandLines.AddCommandLines(lignes);
        }

        public async Task CreateCommand(CdeCli command)
        {
            await _unitOfWork.Commands.CreateCommand(command);
        }

        public async Task<IEnumerable<CdeCli>> GetAllCommands()
        {
            return await _unitOfWork.Commands.GetAllCommands();
        }

        public async Task<IEnumerable<Ligne_Cde_Cli>> GetCommandLinesByCommandId(int id)
        {
            return await _unitOfWork.CommandLines.GetCommandLinesByCommandId(id);
        }

        public async Task<int?> GetLastCommandId()
        {
            return await _unitOfWork.Commands.GetLastCommandId();
        }

        public async Task AddFabrication(Fabrication pizza)
        {
            await _unitOfWork.Fabrications.AddFabrication(pizza);
        }

        public async Task CreateBonLiv(BonLiv bonLiv)
        {
            await _unitOfWork.BonLivs.CreateBonLiv(bonLiv);
        }

        public async Task CreateFacture(Fact_Cli_BonLiv facture)
        {
            await _unitOfWork.Facturations.CreateFacturation(facture);
        }

        public async Task<int?> GetLastFactureId()
        {
            return await _unitOfWork.Facturations.GetLastFactureId();
        }

        public async Task<BonLiv> GetLastBonLiv()
        {
            return await _unitOfWork.BonLivs.GetLastBonLiv();
        }

        public async Task<Fact_Cli_BonLiv> GetLastFacture()
        {
            return await _unitOfWork.Facturations.GetLastFacture();
        }
    }
}
