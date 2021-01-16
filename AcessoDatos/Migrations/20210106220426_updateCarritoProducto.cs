using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class updateCarritoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProductos_Carrito_CarritoId",
                table: "CarritoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProductos_Productos_ProductoId",
                table: "CarritoProductos");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "CarritoProductos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "CarritoProductos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProductos_Carrito_CarritoId",
                table: "CarritoProductos",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProductos_Productos_ProductoId",
                table: "CarritoProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProductos_Carrito_CarritoId",
                table: "CarritoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProductos_Productos_ProductoId",
                table: "CarritoProductos");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "CarritoProductos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "CarritoProductos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProductos_Carrito_CarritoId",
                table: "CarritoProductos",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProductos_Productos_ProductoId",
                table: "CarritoProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
