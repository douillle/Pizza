using Pizza.Core;
using Pizza.Core.Repositories;
using Pizza.Data.Repositories;
using System.Threading.Tasks;

namespace Pizza.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaDbContext _context;
        private ClientRepository _clientRepository;
        private AdresseRepository _adresseRepository;
        private QuartierRepository _quartierRepository;
        private CdeCliRepository _cdeCliRepository;
        private PizzaRepository _pizzaRepository;
        private LigneCommandeRepository _ligneCommandeRepository;
        private FabricationRepository _fabricationRepository;
        private BonLivRepository _bonLivRepository;
        private FacturationRepository _facturationRepository;

        public UnitOfWork(PizzaDbContext context)
        {
            _context = context;
        }

        public IClientRepository Clients => _clientRepository = _clientRepository ?? new ClientRepository(_context);

        public IAdresseRepository Adresses => _adresseRepository = _adresseRepository ?? new AdresseRepository(_context);

        public IQuartierRepository Quartiers => _quartierRepository = _quartierRepository ?? new QuartierRepository(_context);

        public ICdeCliRepository Commands => _cdeCliRepository = _cdeCliRepository ?? new CdeCliRepository(_context);

        public IPizzaRepository Pizzas => _pizzaRepository = _pizzaRepository ?? new PizzaRepository(_context);

        public ILigneCommandeRepository CommandLines => _ligneCommandeRepository = _ligneCommandeRepository ?? new LigneCommandeRepository(_context);

        public IFabricationRepository Fabrications => _fabricationRepository = _fabricationRepository ?? new FabricationRepository(_context);

        public IBonLivRepository BonLivs => _bonLivRepository = _bonLivRepository ?? new BonLivRepository(_context);

        public IFacturationRepository Facturations => _facturationRepository = _facturationRepository ?? new FacturationRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
