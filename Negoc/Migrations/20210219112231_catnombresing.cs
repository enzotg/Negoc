using Microsoft.EntityFrameworkCore.Migrations;

namespace Negoc.Migrations
{
    public partial class catnombresing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreSing",
                table: "Categoria",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreSing",
                table: "Categoria");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
