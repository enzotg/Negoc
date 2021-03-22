using Microsoft.EntityFrameworkCore.Migrations;

namespace Negoc.Migrations
{
    public partial class deporte2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deporte",
                columns: table => new
                {
                    DeporteId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deporte", x => x.DeporteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deporte");
        }
    }
}
