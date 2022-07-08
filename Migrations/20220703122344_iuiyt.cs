using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAxiaMarket.Migrations
{
    public partial class iuiyt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "addedon",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "boutiqueIdBoutique",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "valide",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Boutiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategorie",
                table: "Boutiques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Boutiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "addedon",
                table: "Boutiques",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "Boutiques",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Boutiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Boutiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "valide",
                table: "Boutiques",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "addedon",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "categorieIdCategorie",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Articles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "valide",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commandRefrence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransporterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valide = table.Column<bool>(type: "bit", nullable: false),
                    addedon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    panierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandId);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fournisseurId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clauses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    effectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    addedon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactureRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    addedon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    valide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureId);
                });

            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    PanierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPanier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visitorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addedon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false),
                    valide = table.Column<bool>(type: "bit", nullable: false),
                    IdArticle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.PanierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_boutiqueIdBoutique",
                table: "Categories",
                column: "boutiqueIdBoutique");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_categorieIdCategorie",
                table: "Articles",
                column: "categorieIdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PanierId",
                table: "Articles",
                column: "PanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_categorieIdCategorie",
                table: "Articles",
                column: "categorieIdCategorie",
                principalTable: "Categories",
                principalColumn: "IdCategorie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Paniers_PanierId",
                table: "Articles",
                column: "PanierId",
                principalTable: "Paniers",
                principalColumn: "PanierId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Boutiques_boutiqueIdBoutique",
                table: "Categories",
                column: "boutiqueIdBoutique",
                principalTable: "Boutiques",
                principalColumn: "IdBoutique",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_categorieIdCategorie",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Paniers_PanierId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Boutiques_boutiqueIdBoutique",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_boutiqueIdBoutique",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Articles_categorieIdCategorie",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_PanierId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "addedon",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "boutiqueIdBoutique",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "valide",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "IdCategorie",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "addedon",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "valide",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "addedon",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "categorieIdCategorie",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "valide",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    IdP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotPassP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.IdP);
                });
        }
    }
}
