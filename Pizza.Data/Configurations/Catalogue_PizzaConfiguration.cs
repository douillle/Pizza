using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class Catalogue_PizzaConfiguration : IEntityTypeConfiguration<Catalogue_Pizza>
    {
        public void Configure(EntityTypeBuilder<Catalogue_Pizza> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nom_Pizza)
                .IsRequired();

            builder
                .Property(m => m.Taille_Pizza)
                .IsRequired();

            builder
                .Property(m => m.Prix_Pizza)
                .IsRequired();

            builder
                .ToTable("Catalogue_Pizza");
        }
    }
}
