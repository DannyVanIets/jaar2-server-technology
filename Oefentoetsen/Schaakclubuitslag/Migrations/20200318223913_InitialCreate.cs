using Microsoft.EntityFrameworkCore.Migrations;

namespace Schaakclubuitslag.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCUSpeler",
                columns: table => new
                {
                    SCUSpelerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCUSpeler", x => x.SCUSpelerId);
                });

            migrationBuilder.CreateTable(
                name: "Partij",
                columns: table => new
                {
                    PartijId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dag = table.Column<int>(nullable: false),
                    Uitslag = table.Column<int>(nullable: false),
                    SCUSpelerId = table.Column<int>(nullable: false),
                    SpelerSCUSpelerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partij", x => x.PartijId);
                    table.ForeignKey(
                        name: "FK_Partij_SCUSpeler_SpelerSCUSpelerId",
                        column: x => x.SpelerSCUSpelerId,
                        principalTable: "SCUSpeler",
                        principalColumn: "SCUSpelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partij_SpelerSCUSpelerId",
                table: "Partij",
                column: "SpelerSCUSpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partij");

            migrationBuilder.DropTable(
                name: "SCUSpeler");
        }
    }
}
