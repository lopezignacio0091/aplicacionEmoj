﻿// <auto-generated />
using System;
using AcessoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcessoDatos.Migrations
{
    [DbContext(typeof(BdEmiContext))]
    [Migration("20210119210055_createCompras")]
    partial class createCompras
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcessoDatos.Modelos.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado");

                    b.Property<decimal>("Total");

                    b.Property<int>("UsuarioId");

                    b.HasKey("CarritoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.CarritoProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CarritoId");

                    b.Property<int?>("CompraId");

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Precio");

                    b.Property<int>("ProductoId");

                    b.HasKey("id");

                    b.HasIndex("CarritoId");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CarritoProductos");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Contacto", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Mensaje");

                    b.Property<string>("Nombre");

                    b.HasKey("ContactoId");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Imagen", b =>
                {
                    b.Property<int>("ImagenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagenUrl");

                    b.Property<int>("ProductoId");

                    b.HasKey("ImagenId");

                    b.HasIndex("ProductoId")
                        .IsUnique();

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.Property<int>("Stock");

                    b.Property<int>("StockMinimo");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Email");

                    b.Property<bool>("EsAdmin");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Carrito", b =>
                {
                    b.HasOne("AcessoDatos.Modelos.Usuario")
                        .WithOne("Carrito")
                        .HasForeignKey("AcessoDatos.Modelos.Carrito", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AcessoDatos.Modelos.CarritoProducto", b =>
                {
                    b.HasOne("AcessoDatos.Modelos.Carrito")
                        .WithMany("ListaCarritoProductos")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcessoDatos.Modelos.Compra")
                        .WithMany("listaCarritoProductos")
                        .HasForeignKey("CompraId");

                    b.HasOne("AcessoDatos.Modelos.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AcessoDatos.Modelos.Imagen", b =>
                {
                    b.HasOne("AcessoDatos.Modelos.Producto")
                        .WithOne("Imagen")
                        .HasForeignKey("AcessoDatos.Modelos.Imagen", "ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
