using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class Ligne_Cde_CliConfiguration : IEntityTypeConfiguration<Ligne_Cde_Cli>
    {
        public void Configure(EntityTypeBuilder<Ligne_Cde_Cli> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Quantité)
                .IsRequired();

            builder
                .HasOne(m => m.Commande)
                .WithMany(c => c.Ligne_Commandes)
                .HasForeignKey(m => m.Num_Cde_Cli);

            builder
                .HasOne(m => m.Pizza)
                .WithMany(c => c.Ligne_Commandes)
                .HasForeignKey(m => m.Num_Pizza);

            builder
                .ToTable("Ligne_Cde_Cli");
        }
    }
}
