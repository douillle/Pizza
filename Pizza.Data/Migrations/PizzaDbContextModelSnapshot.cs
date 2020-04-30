﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizza.Data;

namespace Pizza.Data.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizza.Core.Models.Adresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Quartier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Quartier");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Pizza.Core.Models.BonLiv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Liv")
                        .HasColumnType("datetime2");

                    b.Property<int>("Num_Cde_Cli")
                        .HasColumnType("int");

                    b.Property<int?>("Num_Fact")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Cde_Cli");

                    b.HasIndex("Num_Fact");

                    b.ToTable("BonLiv");
                });

            modelBuilder.Entity("Pizza.Core.Models.Catalogue_Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom_Pizza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prix_Pizza")
                        .HasColumnType("int");

                    b.Property<bool>("Taille_Pizza")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Catalogue_Pizza");
                });

            modelBuilder.Entity("Pizza.Core.Models.CdeCli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Cde")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Livre_Emporte")
                        .HasColumnType("bit");

                    b.Property<int>("Num_Cli")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Cli");

                    b.ToTable("CdeCli");
                });

            modelBuilder.Entity("Pizza.Core.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom_Cli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Adresse")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Adresse");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Pizza.Core.Models.Detail_Liv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Num_Adresse")
                        .HasColumnType("int");

                    b.Property<int?>("Num_Bon_Liv")
                        .HasColumnType("int");

                    b.Property<int?>("Num_Liv")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Adresse");

                    b.HasIndex("Num_Bon_Liv");

                    b.HasIndex("Num_Liv");

                    b.ToTable("Detail_Liv");
                });

            modelBuilder.Entity("Pizza.Core.Models.Fabrication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Fab")
                        .HasColumnType("datetime2");

                    b.Property<int>("Num_Pizza")
                        .HasColumnType("int");

                    b.Property<int>("Quant_Fab")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Pizza");

                    b.ToTable("Fabrication");
                });

            modelBuilder.Entity("Pizza.Core.Models.Fact_Cli_BonLiv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Fact_Cli")
                        .HasColumnType("datetime2");

                    b.Property<int>("Montant_Total")
                        .HasColumnType("int");

                    b.Property<int>("Num_Cli")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Cli");

                    b.ToTable("Fact_Cli_BonLiv");
                });

            modelBuilder.Entity("Pizza.Core.Models.Ligne_Cde_Cli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Num_Cde_Cli")
                        .HasColumnType("int");

                    b.Property<int>("Num_Pizza")
                        .HasColumnType("int");

                    b.Property<string>("Quantité")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Num_Cde_Cli");

                    b.HasIndex("Num_Pizza");

                    b.ToTable("Ligne_Cde_Cli");
                });

            modelBuilder.Entity("Pizza.Core.Models.Livraison", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Arrive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Depart")
                        .HasColumnType("datetime2");

                    b.Property<int>("Num_Quartier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Quartier");

                    b.ToTable("Livraison");
                });

            modelBuilder.Entity("Pizza.Core.Models.Livreur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom_Livreur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Quartier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Quartier");

                    b.ToTable("Livreur");
                });

            modelBuilder.Entity("Pizza.Core.Models.Paiement_Cli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Payment")
                        .HasColumnType("datetime2");

                    b.Property<int>("Montant_Payment")
                        .HasColumnType("int");

                    b.Property<int>("Num_Fact")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Num_Fact");

                    b.ToTable("Paiement_Cli");
                });

            modelBuilder.Entity("Pizza.Core.Models.Quartier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom_Quartier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quartier");
                });

            modelBuilder.Entity("Pizza.Core.Models.Adresses", b =>
                {
                    b.HasOne("Pizza.Core.Models.Quartier", "Quartier")
                        .WithMany("Adresses")
                        .HasForeignKey("Num_Quartier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.BonLiv", b =>
                {
                    b.HasOne("Pizza.Core.Models.CdeCli", "CdeCli")
                        .WithMany("BonLivs")
                        .HasForeignKey("Num_Cde_Cli")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizza.Core.Models.Fact_Cli_BonLiv", "Facturation")
                        .WithMany("BonLivs")
                        .HasForeignKey("Num_Fact");
                });

            modelBuilder.Entity("Pizza.Core.Models.CdeCli", b =>
                {
                    b.HasOne("Pizza.Core.Models.Client", "Client")
                        .WithMany("CdeClients")
                        .HasForeignKey("Num_Cli")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Client", b =>
                {
                    b.HasOne("Pizza.Core.Models.Adresses", "Adresse")
                        .WithMany("Clients")
                        .HasForeignKey("Num_Adresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Detail_Liv", b =>
                {
                    b.HasOne("Pizza.Core.Models.Adresses", "Adresse")
                        .WithMany("Detail_Livs")
                        .HasForeignKey("Num_Adresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizza.Core.Models.BonLiv", "BonLiv")
                        .WithMany("Detail_Livs")
                        .HasForeignKey("Num_Bon_Liv");

                    b.HasOne("Pizza.Core.Models.Livraison", "Livraison")
                        .WithMany("Detail_Livs")
                        .HasForeignKey("Num_Liv");
                });

            modelBuilder.Entity("Pizza.Core.Models.Fabrication", b =>
                {
                    b.HasOne("Pizza.Core.Models.Catalogue_Pizza", "Pizza")
                        .WithMany("Fabrications")
                        .HasForeignKey("Num_Pizza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Fact_Cli_BonLiv", b =>
                {
                    b.HasOne("Pizza.Core.Models.Client", "Client")
                        .WithMany("Factures")
                        .HasForeignKey("Num_Cli")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Ligne_Cde_Cli", b =>
                {
                    b.HasOne("Pizza.Core.Models.CdeCli", "Commande")
                        .WithMany("Ligne_Commandes")
                        .HasForeignKey("Num_Cde_Cli")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizza.Core.Models.Catalogue_Pizza", "Pizza")
                        .WithMany("Ligne_Commandes")
                        .HasForeignKey("Num_Pizza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Livraison", b =>
                {
                    b.HasOne("Pizza.Core.Models.Quartier", "Quartier")
                        .WithMany("Livraisons")
                        .HasForeignKey("Num_Quartier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Livreur", b =>
                {
                    b.HasOne("Pizza.Core.Models.Quartier", "Quartier")
                        .WithMany("Livreurs")
                        .HasForeignKey("Num_Quartier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizza.Core.Models.Paiement_Cli", b =>
                {
                    b.HasOne("Pizza.Core.Models.Fact_Cli_BonLiv", "Facturation")
                        .WithMany("Payments")
                        .HasForeignKey("Num_Fact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}