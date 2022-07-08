using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAxiaMarket.Migrations
{
    public partial class initialcreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    IdP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotPassP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneP = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.IdP);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
