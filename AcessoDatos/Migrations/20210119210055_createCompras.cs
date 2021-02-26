using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDatos.Migrations
{
    public partial class createCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Imagenes_ProductoId",
                table: "Imagenes");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "CarritoProductos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ProductoId",
                table: "Imagenes",
                column: "ProductoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_CompraId",
                table: "CarritoProductos",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProductos_Compras_CompraId",
                table: "CarritoProductos",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProductos_Compras_CompraId",
                table: "CarritoProductos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Imagenes_ProductoId",
                table: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_CarritoProductos_CompraId",
                table: "CarritoProductos");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "CarritoProductos");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ProductoId",
                table: "Imagenes",
                column: "ProductoId");
        }
    }
}
