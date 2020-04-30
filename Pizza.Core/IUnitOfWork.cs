using Pizza.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IAdresseRepository Adresses { get; }
        IQuartierRepository Quartiers { get; }
        ICdeCliRepository Commands { get; }
        IPizzaRepository Pizzas { get; }
        ILigneCommandeRepository CommandLines { get; }
        IFabricationRepository Fabrications { get; }
        IBonLivRepository BonLivs { get; }
        IFacturationRepository Facturations { get; }

        Task<int> CommitAsync();
    }
}
