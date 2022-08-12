using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moha.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mosques",
                columns: table => new
                {
                    mosqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mosques", x => x.mosqueId);
                });

            migrationBuilder.CreateTable(
                name: "participents",
                columns: table => new
                {
                    ParticipentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    mosqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participents", x => x.ParticipentId);
                    table.ForeignKey(
                        name: "FK_participents_mosques_mosqueId",
                        column: x => x.mosqueId,
                        principalTable: "mosques",
                        principalColumn: "mosqueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_participents_mosqueId",
                table: "participents",
                column: "mosqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participents");

            migrationBuilder.DropTable(
                name: "mosques");
        }
    }
}
