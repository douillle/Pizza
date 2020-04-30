using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class Fact_Cli_BonLivConfiguration : IEntityTypeConfiguration<Fact_Cli_BonLiv>
    {
        public void Configure(EntityTypeBuilder<Fact_Cli_BonLiv> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date_Fact_Cli)
                .IsRequired();

            builder
                .Property(m => m.Montant_Total)
                .IsRequired();

            builder
                .HasOne(m => m.Client)
                .WithMany(c => c.Factures)
                .HasForeignKey(m => m.Num_Cli);

            builder
                .ToTable("Fact_Cli_BonLiv");
        }
    }
}
