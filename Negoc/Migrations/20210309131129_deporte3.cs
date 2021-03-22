using Microsoft.EntityFrameworkCore.Migrations;

namespace Negoc.Migrations
{
    public partial class deporte3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Producto_DeporteId",
                table: "Producto",
                column: "DeporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Deporte_DeporteId",
                table: "Producto",
                column: "DeporteId",
                principalTable: "Deporte",
                principalColumn: "DeporteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Deporte_DeporteId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_DeporteId",
                table: "Producto");
        }
    }
}
