using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAxiaMarket1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresseP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomP",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrenomP",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TelephoneP",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresseP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrenomP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelephoneP",
                table: "AspNetUsers");
        }
    }
}
