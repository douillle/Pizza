using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class QuartierConfiguration : IEntityTypeConfiguration<Quartier>
    {
        public void Configure(EntityTypeBuilder<Quartier> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nom_Quartier)
                .IsRequired();

            builder
                .ToTable("Quartier");
        }
    }
}
