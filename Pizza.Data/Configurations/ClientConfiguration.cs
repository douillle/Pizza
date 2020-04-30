using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Core.Models;

namespace Pizza.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nom_Cli)
                .IsRequired();

            builder
                .HasOne(m => m.Adresse)
                .WithMany(c => c.Clients)
                .HasForeignKey(m => m.Num_Adresse);

            builder
                .ToTable("Client");
        }
    }
}
