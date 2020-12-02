using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class UpdateCarrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Usuarios_usuarioCarritoUsuarioId",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_usuarioCarritoUsuarioId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "usuarioCarritoUsuarioId",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carrito",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "usuarioCarritoUsuarioId",
                table: "Carrito",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_usuarioCarritoUsuarioId",
                table: "Carrito",
                column: "usuarioCarritoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Usuarios_usuarioCarritoUsuarioId",
                table: "Carrito",
                column: "usuarioCarritoUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
