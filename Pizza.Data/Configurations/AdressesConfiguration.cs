using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class AdressesConfiguration : IEntityTypeConfiguration<Adresses>
    {
        public void Configure(EntityTypeBuilder<Adresses> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Adresse)
                .IsRequired();

            builder
                .HasOne(m => m.Quartier)
                .WithMany(c => c.Adresses)
                .HasForeignKey(m => m.Num_Quartier);

            builder
                .ToTable("Adresses");
        }
    }
}
