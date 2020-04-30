using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class QuartierService : IQuartierService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuartierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Quartier>> GetAllDistricts()
        {
            return await _unitOfWork.Quartiers.GetAllDistricts();
        }
    }
}
