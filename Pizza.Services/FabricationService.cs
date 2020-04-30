using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class FabricationService : IFabricationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FabricationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddFabrication(Fabrication pizza)
        {
            await _unitOfWork.Fabrications.AddFabrication(pizza);
        }
    }
}
