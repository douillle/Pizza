using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Models;
using Pizza.Core.Services;
using System.Threading.Tasks;

namespace Pizza.Api.Controllers
{
    public class ResumeCommandController : Controller
    {
        #region Fields 
        private readonly ICdeCliService _commandService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ResumeCommandController(ICdeCliService cdeCliService, IMapper mapper)
        {
            _commandService = cdeCliService;
            _mapper = mapper;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var bonLiv = await _commandService.GetLastBonLiv();
            var facture = await _commandService.GetLastFacture();

            var bonlivViewModel = _mapper.Map<BonLivViewModel>(bonLiv);
            var factViewModel = _mapper.Map<FacturationViewModel>(facture);

            var resume = new ResumeViewModel { BonLiv = bonlivViewModel, Facturation = factViewModel };

            return View(resume);
        }
    }
}