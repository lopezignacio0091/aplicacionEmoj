using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class usuarioCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Compras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_usuarioId",
                table: "Compras",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuarios_usuarioId",
                table: "Compras",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuarios_usuarioId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_usuarioId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Compras");
        }
    }
}
