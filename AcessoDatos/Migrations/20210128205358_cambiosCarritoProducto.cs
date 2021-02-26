using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class cambiosCarritoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CarritoProductos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CarritoProductos");
        }
    }
}
