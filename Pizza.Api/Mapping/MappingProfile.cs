using AutoMapper;
using Pizza.Api.Models;
using Pizza.Api.Models.SaveModel;
using Pizza.Core.Models;

namespace Pizza.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to ViewModel
            CreateMap<Client, ClientViewModel>();
            CreateMap<Adresses, AdresseViewModel>();
            CreateMap<Quartier, QuartierViewModel>();
            CreateMap<CdeCli, CommandViewModel>();
            CreateMap<Catalogue_Pizza, PizzaViewModel>();
            CreateMap<BonLiv, BonLivViewModel>();
            CreateMap<Fact_Cli_BonLiv, FacturationViewModel>();

            // ViewModel to Model
            CreateMap<ClientViewModel, Client>();
            CreateMap<AdresseViewModel, Adresses>();
            CreateMap<QuartierViewModel, Quartier>();
            CreateMap<CommandViewModel, CdeCli>();
            CreateMap<PizzaViewModel, Catalogue_Pizza>();

            // SavingModel to Model
            CreateMap<SaveClientModel, Client>()
                .ForMember(c => c.Adresse, opt => opt.Ignore());
            CreateMap<SaveCommandModel, CdeCli>()
                .ForMember(c => c.Ligne_Commandes, opt => opt.Ignore())
                .ForMember(c => c.Client, opt => opt.Ignore());
            CreateMap<SaveCommandLinesModel, Ligne_Cde_Cli>()
                .ForMember(c => c.Pizza, opt => opt.Ignore());
        }

    }
}
