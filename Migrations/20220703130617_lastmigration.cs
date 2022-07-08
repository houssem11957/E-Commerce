using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAxiaMarket.Migrations
{
    public partial class lastmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IdArticle",
                table: "Paniers");

            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "boutiqueIdBoutique",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdCategorie",
                table: "Boutiques");

            migrationBuilder.DropColumn(
                name: "categorieIdCategorie",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "IdArticle",
                table: "Categories",
                newName: "boutiqueId");

            migrationBuilder.RenameColumn(
                name: "PanierId",
                table: "Articles",
                newName: "panierId");

            migrationBuilder.AlterColumn<int>(
                name: "panierId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "boutiqueId",
                table: "Categories",
                newName: "IdArticle");

            migrationBuilder.RenameColumn(
                name: "panierId",
                table: "Articles",
                newName: "PanierId");

            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Paniers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Commandes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "boutiqueIdBoutique",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategorie",
                table: "Boutiques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PanierId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "categorieIdCategorie",
                table: "Articles",
                type: "int",
                nullable: true);

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
    }
}
