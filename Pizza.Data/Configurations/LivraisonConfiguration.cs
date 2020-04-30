using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class LivraisonConfiguration : IEntityTypeConfiguration<Livraison>
    {
        public void Configure(EntityTypeBuilder<Livraison> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date_Depart)
                .IsRequired();

            builder
                .Property(m => m.Date_Arrive)
                .IsRequired();

            builder
                .HasOne(m => m.Quartier)
                .WithMany(c => c.Livraisons)
                .HasForeignKey(m => m.Num_Quartier);

            builder
                .ToTable("Livraison");
        }
    }
}
