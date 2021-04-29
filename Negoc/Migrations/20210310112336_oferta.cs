using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Negoc.Migrations
{
    public partial class oferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
                });

            migrationBuilder.CreateTable(
                name: "OfertaProducto",
                columns: table => new
                {
                    OfertaProductoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<long>(nullable: false),
                    OfertaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaProducto", x => x.OfertaProductoId);
                    table.ForeignKey(
                        name: "FK_OfertaProducto_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfertaProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertaProducto_OfertaId",
                table: "OfertaProducto",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaProducto_ProductoId",
                table: "OfertaProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertaProducto");

            migrationBuilder.DropTable(
                name: "Oferta");
        }
    }
}
