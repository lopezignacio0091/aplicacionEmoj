using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class carrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Productos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usuarioCarritoUsuarioId = table.Column<int>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuarios_usuarioCarritoUsuarioId",
                        column: x => x.usuarioCarritoUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_usuarioCarritoUsuarioId",
                table: "Carrito",
                column: "usuarioCarritoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Carrito_CarritoId",
                table: "Productos",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Carrito_CarritoId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Productos");
        }
    }
}
