using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class LivreurConfiguration : IEntityTypeConfiguration<Livreur>
    {
        public void Configure(EntityTypeBuilder<Livreur> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nom_Livreur)
                .IsRequired();

            builder
                .HasOne(m => m.Quartier)
                .WithMany(c => c.Livreurs)
                .HasForeignKey(m => m.Num_Quartier);

            builder
                .ToTable("Livreur");
        }
    }
}
