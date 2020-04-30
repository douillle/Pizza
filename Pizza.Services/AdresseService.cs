using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class AdresseService : IAdresseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdresseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAddress(Adresses adresse)
        {
            await _unitOfWork.Adresses.CreateAddress(adresse);
        }

        public async Task<Adresses> GetAdresseByText(string adresse)
        {
            return await _unitOfWork.Adresses.GetAdresseByText(adresse);
        }
    }
}
