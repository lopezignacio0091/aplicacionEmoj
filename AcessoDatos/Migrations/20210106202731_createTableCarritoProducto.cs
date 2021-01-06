using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class createTableCarritoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Carrito_CarritoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Carrito",
                newName: "Fecha");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Carrito",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Carrito",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CarritoProductos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: true),
                    CarritoId = table.Column<int>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProductos", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarritoProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_CarritoId",
                table: "CarritoProductos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_ProductoId",
                table: "CarritoProductos",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProductos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Carrito");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Carrito",
                newName: "fecha");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Productos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Carrito_CarritoId",
                table: "Productos",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
