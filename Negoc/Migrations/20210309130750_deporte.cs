using Microsoft.EntityFrameworkCore.Migrations;

namespace Negoc.Migrations
{
    public partial class deporte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeporteId",
                table: "Producto",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeporteId",
                table: "Producto");
        }
    }
}
