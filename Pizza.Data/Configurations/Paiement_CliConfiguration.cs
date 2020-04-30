using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class Paiement_CliConfiguration : IEntityTypeConfiguration<Paiement_Cli>
    {
        public void Configure(EntityTypeBuilder<Paiement_Cli> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date_Payment)
                .IsRequired();

            builder
                .Property(m => m.Montant_Payment)
                .IsRequired();

            builder
                .HasOne(m => m.Facturation)
                .WithMany(c => c.Payments)
                .HasForeignKey(m => m.Num_Fact);

            builder
                .ToTable("Paiement_Cli");
        }
    }
}
