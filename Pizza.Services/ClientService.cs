using Pizza.Core;
using Pizza.Core.Models;
using Pizza.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddClient(Client client)
        {
            await _unitOfWork.Clients.AddClient(client);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _unitOfWork.Clients.GetAllClients();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _unitOfWork.Clients.GetClientById(id);
        }

        public async Task<int?> GetClientIdByName(string name)
        {
            return await _unitOfWork.Clients.GetClientIdByName(name);
        }
    }
}
