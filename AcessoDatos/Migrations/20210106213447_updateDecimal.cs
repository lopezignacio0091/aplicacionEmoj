using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class updateDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "CarritoProductos",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "CarritoProductos",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
