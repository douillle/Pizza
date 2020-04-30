using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class FabricationConfiguration : IEntityTypeConfiguration<Fabrication>
    {
        public void Configure(EntityTypeBuilder<Fabrication> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Quant_Fab)
                .IsRequired();

            builder
                .Property(m => m.Date_Fab)
                .IsRequired();

            builder
                .HasOne(m => m.Pizza)
                .WithMany(c => c.Fabrications)
                .HasForeignKey(m => m.Num_Pizza);

            builder
                .ToTable("Fabrication");
        }
    }
}
