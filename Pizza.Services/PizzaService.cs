using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas()
        {
            return await _unitOfWork.Pizzas.GetAllPizzas();
        }

        public async Task<Catalogue_Pizza> GetPizzaById(int id)
        {
            return await _unitOfWork.Pizzas.GetPizzaById(id);
        }
    }
}
