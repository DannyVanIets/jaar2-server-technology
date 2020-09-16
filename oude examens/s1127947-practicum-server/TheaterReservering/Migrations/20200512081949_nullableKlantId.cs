using Microsoft.EntityFrameworkCore.Migrations;

namespace TheaterReservering.Migrations
{
    public partial class nullableKlantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Reservering",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "KlantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Reservering",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservering_Klant_KlantId",
                table: "Reservering",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "KlantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
