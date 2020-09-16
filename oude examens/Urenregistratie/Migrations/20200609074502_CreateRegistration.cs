using Microsoft.EntityFrameworkCore.Migrations;

namespace Urenregistratie.Migrations
{
    public partial class CreateRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registratie",
                columns: table => new
                {
                    RegistratieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jaar = table.Column<int>(maxLength: 9999, nullable: false),
                    Week = table.Column<int>(maxLength: 53, nullable: false),
                    Maandag = table.Column<int>(nullable: true),
                    Dinsdag = table.Column<int>(nullable: true),
                    Woensdag = table.Column<int>(nullable: true),
                    Donderdag = table.Column<int>(nullable: true),
                    Vrijdag = table.Column<int>(nullable: true),
                    Zaterdag = table.Column<int>(nullable: true),
                    Zondag = table.Column<int>(nullable: true),
                    MedewerkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registratie", x => x.RegistratieId);
                    table.ForeignKey(
                        name: "FK_Registratie_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "MedewerkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registratie_MedewerkerId",
                table: "Registratie",
                column: "MedewerkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registratie");
        }
    }
}
