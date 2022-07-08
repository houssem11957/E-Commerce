using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAxiaMarket.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrenomP",
                table: "Personnes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrenomP",
                table: "Personnes");
        }
    }
}
