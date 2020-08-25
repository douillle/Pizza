using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pizza.Api.Models;
using Pizza.Api.Models.SaveModel;
using Pizza.Api.Validations;
using Pizza.Core.Models;
using Pizza.Core.Services;
using Pizza.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Pizza.Api.Controllers
{
    public class CommandeController : Controller
    {
        #region Fields 
        private readonly ICdeCliService _commandService;
        private readonly IClientService _clientService;
        private readonly IPizzaService _pizzaService;
        private readonly IQuartierService _quartierService;
        private readonly IAdresseService _adresseService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CommandeController(ICdeCliService cdeCliService, IClientService clientService, 
            IPizzaService pizzaService, IMapper mapper, IQuartierService quartierService, IAdresseService adresseService)
        {
            _commandService = cdeCliService;
            _clientService = clientService;
            _pizzaService = pizzaService;
            _quartierService = quartierService;
            _adresseService = adresseService;
            _mapper = mapper;
        }
        #endregion

        #region Properties
        private IList<SaveCommandLinesModel> _lignesCommande = new List<SaveCommandLinesModel>();
        #endregion

        #region Routes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var commands = await _commandService.GetAllCommands();
            var commandsView = _mapper.Map<IEnumerable<CommandViewModel>>(commands);
            return View(commandsView.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var quartiers = await _quartierService.GetAllDistricts();
            var quartierViewModel = _mapper.Map<IEnumerable<QuartierViewModel>>(quartiers);

            ViewData["Num_Quartier"] = new SelectList(quartierViewModel, "Id", "Nom_Quartier");

            var pizzas = await _pizzaService.GetAllPizzas();
            var pizzaViewModel = _mapper.Map<IEnumerable<PizzaViewModel>>(pizzas);

            var quantities = new List<int>();
            for(var i=1; i <= 10; i++)
            {
                quantities.Add(i);
            }

            ViewData["Num_Pizza"] = new SelectList(pizzaViewModel, "Id", "PizzaToDiplay");
            ViewData["Qte_Pizza"] = new SelectList(quantities);

            if (TempData["ligne"] != null && _lignesCommande != null && _lignesCommande.Any())
            {
                var com = new SaveCommandModel();
                com.Ligne_Commandes = TempData.Get<IList<SaveCommandLinesModel>>("ligne");
                TempData.Keep("ligne");

                return View(com);
            }
            var command = new SaveCommandModel();
            command.Client = new SaveClientModel();

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Livre_Emporte,Client,Num_Pizza,Qte_Pizza,Ligne_Commandes")] SaveCommandModel commandView, string command)
        {
            if(command == "Ajouter une commande")
            {
                var lines = TempData.Get<IList<SaveCommandLinesModel>>("ligne");
                var pizza = await _pizzaService.GetPizzaById(commandView.Num_Pizza);
                var pizzaViewModel = _mapper.Map<PizzaViewModel>(pizza);
                if (lines != null && lines.Any())
                {
                    lines.Add(new SaveCommandLinesModel { Num_Pizza = commandView.Num_Pizza, Quantité = commandView.Qte_Pizza.ToString(), Pizza = pizzaViewModel });
                    _lignesCommande = lines.ToList();
                }
                else
                {
                    lines = new List<SaveCommandLinesModel>  { new SaveCommandLinesModel { Num_Pizza = commandView.Num_Pizza, Quantité = commandView.Qte_Pizza.ToString(), Pizza = pizzaViewModel } };
                    _lignesCommande = lines.ToList();
                }
                TempData.Put("ligne", lines);

                return await Create();
            }
            else
            {
                var lines = TempData.Get<IList<SaveCommandLinesModel>>("ligne");
                commandView.Ligne_Commandes = lines;

                var validator = new SaveCommandModelValidator();
                var validationResult = await validator.ValidateAsync(commandView);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var clientId = await _clientService.GetClientIdByName(commandView.Client.Nom_Cli);

                if (clientId == null)
                {
                    var adresseId = await GetAdressIdForCustomer(commandView.Client.Adresse, commandView.Client.Num_Quartier);

                    var clientToCreate = new Client { Nom_Cli = commandView.Client.Nom_Cli, Num_Adresse = adresseId };
                    await _clientService.AddClient(clientToCreate);

                    clientId = clientToCreate.Id;
                }

                commandView.Num_Cli = (int)clientId;
                commandView.Date_Cde = DateTime.Now;
                var commandToCreate = _mapper.Map<SaveCommandModel, CdeCli>(commandView);

                await _commandService.CreateCommand(commandToCreate);

                //Recup l'id de la nouvelle commande créée pour les lignes de commande
                var cdeId = await _commandService.GetLastCommandId();

                if(cdeId != null)
                {
                    var montantTotal = 0;

                    foreach (var line in lines)
                    {
                        line.Num_Cde_Cli = cdeId;

                        // Création de la fabrication
                        var fab = new Fabrication { Num_Pizza = line.Num_Pizza, Quant_Fab = int.Parse(line.Quantité), Date_Fab = DateTime.Now};
                        await _commandService.AddFabrication(fab);

                        montantTotal += (int)line.MontantTotal;
                    }

                    // Création des lignes de commande client
                    var linesToCreate = _mapper.Map<IEnumerable<SaveCommandLinesModel>, IEnumerable<Ligne_Cde_Cli>>(lines);
                    await _commandService.AddCommandLines(linesToCreate);

                    // Création de la facture
                    var factureToCreate = new Fact_Cli_BonLiv { Num_Cli = commandView.Num_Cli, Montant_Total = montantTotal, Date_Fact_Cli = DateTime.Now.Date };
                    await _commandService.CreateFacture(factureToCreate);

                    // Création du bon de livraison
                    var factureId = await _commandService.GetLastFactureId();
                    var bonLivToCreate = new BonLiv { Num_Cde_Cli = (int)cdeId, Num_Fact = factureId, Date_Liv = DateTime.Now };
                    await _commandService.CreateBonLiv(bonLivToCreate);
                }

                return RedirectToAction("Index","ResumeCommand");

            }

        }
        #endregion

        #region Methods
        public async Task<int> GetAdressIdForCustomer(string adresseLabel, int quartierId)
        {
            var adresse = await _adresseService.GetAdresseByText(adresseLabel);

            if (adresse == null || adresse.Num_Quartier != quartierId)
            {
                var addressToCreate = new Adresses { Num_Quartier = quartierId, Adresse = adresseLabel };
                await _adresseService.CreateAddress(addressToCreate);

                adresse = addressToCreate;
            }

            return adresse.Id;
        }
        #endregion
    }
}