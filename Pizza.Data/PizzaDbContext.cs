using Microsoft.EntityFrameworkCore;
using Pizza.Core.Models;
using Pizza.Data.Configurations;

namespace Pizza.Data
{
    public class PizzaDbContext : DbContext
    {
        #region DbSet
        public DbSet<Client> Client { get; set; }
        public DbSet<CdeCli> CdeCli { get; set; }
        public DbSet<Ligne_Cde_Cli> Ligne_Cde_Cli { get; set; }
        public DbSet<Catalogue_Pizza> Catalogue_Pizza { get; set; }
        public DbSet<Fabrication> Fabrications { get; set; }
        public DbSet<BonLiv> BonLiv { get; set; }
        public DbSet<Fact_Cli_BonLiv> Fact_Cli_BonLiv { get; set; }
        public DbSet<Paiement_Cli> Paiement_Cli { get; set; }
        public DbSet<Detail_Liv> Detail_Liv { get; set; }
        public DbSet<Livraison> Livraison { get; set; }
        public DbSet<Quartier> Quartier { get; set; }
        public DbSet<Livreur> Livreur { get; set; }
        public DbSet<Adresses> Adresses { get; set; }
        #endregion

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .ApplyConfiguration(new ClientConfiguration());

            builder
                .ApplyConfiguration(new CdeCliConfiguration());

            builder
                .ApplyConfiguration(new Ligne_Cde_CliConfiguration());

            builder
                .ApplyConfiguration(new Catalogue_PizzaConfiguration());

            builder
                .ApplyConfiguration(new FabricationConfiguration());

            builder
                .ApplyConfiguration(new BonLivConfiguration());

            builder
                .ApplyConfiguration(new Fact_Cli_BonLivConfiguration());

            builder
                .ApplyConfiguration(new Paiement_CliConfiguration());

            builder
                .ApplyConfiguration(new Detail_LivConfiguration());

            builder
                .ApplyConfiguration(new LivraisonConfiguration());

            builder
                .ApplyConfiguration(new QuartierConfiguration());

            builder
                .ApplyConfiguration(new LivreurConfiguration());

            builder
                .ApplyConfiguration(new AdressesConfiguration());
        }
    }
}
