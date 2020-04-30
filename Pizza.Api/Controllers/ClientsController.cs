using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pizza.Api.Models;
using Pizza.Api.Models.SaveModel;
using Pizza.Api.Validations;
using Pizza.Core.Models;
using Pizza.Core.Services;

namespace Pizza.Api.Controllers
{
    public class ClientsController : Controller
    {

        #region Fields
        private readonly IClientService _clientService;
        private readonly IAdresseService _adresseService;
        private readonly IQuartierService _quartierService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ClientsController(IClientService clientService, IAdresseService adresseService, IQuartierService quartierService, IMapper mapper)
        {
            _clientService = clientService;
            _adresseService = adresseService;
            _quartierService = quartierService;
            _mapper = mapper;

        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetAllClients();
            var clientsView = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);
            return View(clientsView.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {

            var client = await _clientService.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientView = _mapper.Map<ClientViewModel>(client);

            return View(clientView);
        }


        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            var quartiers = await _quartierService.GetAllDistricts();
            var quartierViewModel = _mapper.Map<IEnumerable<QuartierViewModel>>(quartiers);

            ViewData["Num_Quartier"] = new SelectList(quartierViewModel,"Id", "Nom_Quartier");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom_Cli,Adresse,Num_Quartier")] SaveClientModel clientView)
        {
            var validator = new SaveClientModelValidator();
            var validationResult = await validator.ValidateAsync(clientView);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var adresse = await _adresseService.GetAdresseByText(clientView.Adresse);

            if (adresse == null)
            {
                var addressToCreate = new Adresses { Num_Quartier = clientView.Num_Quartier, Adresse = clientView.Adresse };
                await _adresseService.CreateAddress(addressToCreate);

                adresse = addressToCreate;
            }

            clientView.Num_Adresse = adresse.Id;
            var clientToCreate = _mapper.Map<SaveClientModel, Client>(clientView);

            await _clientService.AddClient(clientToCreate);

            return RedirectToAction(nameof(Index));
        }
    }
}
