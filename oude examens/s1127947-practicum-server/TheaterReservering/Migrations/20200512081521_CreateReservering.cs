using Microsoft.EntityFrameworkCore.Migrations;

namespace TheaterReservering.Migrations
{
    public partial class CreateReservering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    KlantId = table.Column<int>(nullable: true),
                    bezet = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.ReserveringId);
                    table.ForeignKey(
                        name: "FK_Reservering_Klant_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klant",
                        principalColumn: "KlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_KlantId",
                table: "Reservering",
                column: "KlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservering");
        }
    }
}
