using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moha.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participents_mosques_mosqueId",
                table: "participents");

            migrationBuilder.AlterColumn<int>(
                name: "mosqueId",
                table: "participents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_participents_mosques_mosqueId",
                table: "participents",
                column: "mosqueId",
                principalTable: "mosques",
                principalColumn: "mosqueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participents_mosques_mosqueId",
                table: "participents");

            migrationBuilder.AlterColumn<int>(
                name: "mosqueId",
                table: "participents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_participents_mosques_mosqueId",
                table: "participents",
                column: "mosqueId",
                principalTable: "mosques",
                principalColumn: "mosqueId");
        }
    }
}
