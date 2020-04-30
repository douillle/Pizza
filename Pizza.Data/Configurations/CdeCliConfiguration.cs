using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class CdeCliConfiguration : IEntityTypeConfiguration<CdeCli>
    {
        public void Configure(EntityTypeBuilder<CdeCli> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Livre_Emporte)
                .IsRequired();

            builder
                .Property(m => m.Date_Cde)
                .IsRequired();

            builder
                .HasOne(m => m.Client)
                .WithMany(c => c.CdeClients)
                .HasForeignKey(m => m.Num_Cli);

            builder
                .ToTable("CdeCli");
        }
    }
}
