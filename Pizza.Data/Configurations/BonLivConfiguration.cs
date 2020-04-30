using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class BonLivConfiguration : IEntityTypeConfiguration<BonLiv>
    {
        public void Configure(EntityTypeBuilder<BonLiv> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date_Liv)
                .IsRequired();

            builder
                .HasOne(m => m.CdeCli)
                .WithMany(c => c.BonLivs)
                .HasForeignKey(m => m.Num_Cde_Cli);

            builder
                .HasOne(m => m.Facturation)
                .WithMany(c => c.BonLivs)
                .HasForeignKey(m => m.Num_Fact);

            builder
                .ToTable("BonLiv");
        }
    }
}
