using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class agregoCarritoIdUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Usuarios_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarritoId1",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Productos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarritoId1",
                table: "Usuarios",
                column: "CarritoId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Carrito_CarritoId1",
                table: "Usuarios",
                column: "CarritoId1",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Carrito_CarritoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Carrito_CarritoId1",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CarritoId1",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CarritoId1",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Productos");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Usuarios_UsuarioId",
                table: "Carrito",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
