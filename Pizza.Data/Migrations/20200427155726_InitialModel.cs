using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogue_Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Pizza = table.Column<string>(nullable: false),
                    Taille_Pizza = table.Column<bool>(nullable: false),
                    Prix_Pizza = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue_Pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quartier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Quartier = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Pizza = table.Column<int>(nullable: false),
                    Quant_Fab = table.Column<int>(nullable: false),
                    Date_Fab = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabrication_Catalogue_Pizza_Num_Pizza",
                        column: x => x.Num_Pizza,
                        principalTable: "Catalogue_Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(nullable: false),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livraison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Depart = table.Column<DateTime>(nullable: false),
                    Date_Arrive = table.Column<DateTime>(nullable: false),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livraison", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livraison_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livreur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Livreur = table.Column<string>(nullable: false),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livreur_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Cli = table.Column<string>(nullable: false),
                    Num_Adresse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Adresses_Num_Adresse",
                        column: x => x.Num_Adresse,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CdeCli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cli = table.Column<int>(nullable: false),
                    Livre_Emporte = table.Column<bool>(nullable: false),
                    Date_Cde = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdeCli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CdeCli_Client_Num_Cli",
                        column: x => x.Num_Cli,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fact_Cli_BonLiv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Fact_Cli = table.Column<DateTime>(nullable: false),
                    Montant_Total = table.Column<int>(nullable: false),
                    Num_Cli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fact_Cli_BonLiv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fact_Cli_BonLiv_Client_Num_Cli",
                        column: x => x.Num_Cli,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ligne_Cde_Cli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cde_Cli = table.Column<int>(nullable: false),
                    Num_Pizza = table.Column<int>(nullable: false),
                    Quantité = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligne_Cde_Cli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ligne_Cde_Cli_CdeCli_Num_Cde_Cli",
                        column: x => x.Num_Cde_Cli,
                        principalTable: "CdeCli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ligne_Cde_Cli_Catalogue_Pizza_Num_Pizza",
                        column: x => x.Num_Pizza,
                        principalTable: "Catalogue_Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonLiv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cde_Cli = table.Column<int>(nullable: false),
                    Date_Liv = table.Column<DateTime>(nullable: false),
                    Num_Fact = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonLiv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonLiv_CdeCli_Num_Cde_Cli",
                        column: x => x.Num_Cde_Cli,
                        principalTable: "CdeCli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonLiv_Fact_Cli_BonLiv_Num_Fact",
                        column: x => x.Num_Fact,
                        principalTable: "Fact_Cli_BonLiv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiement_Cli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Fact = table.Column<int>(nullable: false),
                    Date_Payment = table.Column<DateTime>(nullable: false),
                    Montant_Payment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement_Cli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiement_Cli_Fact_Cli_BonLiv_Num_Fact",
                        column: x => x.Num_Fact,
                        principalTable: "Fact_Cli_BonLiv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detail_Liv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Bon_Liv = table.Column<int>(nullable: true),
                    Num_Liv = table.Column<int>(nullable: true),
                    Num_Adresse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Liv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Liv_Adresses_Num_Adresse",
                        column: x => x.Num_Adresse,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Liv_BonLiv_Num_Bon_Liv",
                        column: x => x.Num_Bon_Liv,
                        principalTable: "BonLiv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detail_Liv_Livraison_Num_Liv",
                        column: x => x.Num_Liv,
                        principalTable: "Livraison",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_Num_Quartier",
                table: "Adresses",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_BonLiv_Num_Cde_Cli",
                table: "BonLiv",
                column: "Num_Cde_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_BonLiv_Num_Fact",
                table: "BonLiv",
                column: "Num_Fact");

            migrationBuilder.CreateIndex(
                name: "IX_CdeCli_Num_Cli",
                table: "CdeCli",
                column: "Num_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Num_Adresse",
                table: "Client",
                column: "Num_Adresse");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Liv_Num_Adresse",
                table: "Detail_Liv",
                column: "Num_Adresse");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Liv_Num_Bon_Liv",
                table: "Detail_Liv",
                column: "Num_Bon_Liv");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Liv_Num_Liv",
                table: "Detail_Liv",
                column: "Num_Liv");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_Num_Pizza",
                table: "Fabrication",
                column: "Num_Pizza");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Cli_BonLiv_Num_Cli",
                table: "Fact_Cli_BonLiv",
                column: "Num_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Ligne_Cde_Cli_Num_Cde_Cli",
                table: "Ligne_Cde_Cli",
                column: "Num_Cde_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Ligne_Cde_Cli_Num_Pizza",
                table: "Ligne_Cde_Cli",
                column: "Num_Pizza");

            migrationBuilder.CreateIndex(
                name: "IX_Livraison_Num_Quartier",
                table: "Livraison",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_Cli_Num_Fact",
                table: "Paiement_Cli",
                column: "Num_Fact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail_Liv");

            migrationBuilder.DropTable(
                name: "Fabrication");

            migrationBuilder.DropTable(
                name: "Ligne_Cde_Cli");

            migrationBuilder.DropTable(
                name: "Livreur");

            migrationBuilder.DropTable(
                name: "Paiement_Cli");

            migrationBuilder.DropTable(
                name: "BonLiv");

            migrationBuilder.DropTable(
                name: "Livraison");

            migrationBuilder.DropTable(
                name: "Catalogue_Pizza");

            migrationBuilder.DropTable(
                name: "CdeCli");

            migrationBuilder.DropTable(
                name: "Fact_Cli_BonLiv");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Quartier");
        }
    }
}
