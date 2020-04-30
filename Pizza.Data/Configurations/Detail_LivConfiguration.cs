using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class Detail_LivConfiguration : IEntityTypeConfiguration<Detail_Liv>
    {
        public void Configure(EntityTypeBuilder<Detail_Liv> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.BonLiv)
                .WithMany(c => c.Detail_Livs)
                .HasForeignKey(m => m.Num_Bon_Liv);

            builder
                .HasOne(m => m.Adresse)
                .WithMany(c => c.Detail_Livs)
                .HasForeignKey(m => m.Num_Adresse);

            builder
                .HasOne(m => m.Livraison)
                .WithMany(c => c.Detail_Livs)
                .HasForeignKey(m => m.Num_Liv);

            builder
                .ToTable("Detail_Liv");
        }
    }
}
