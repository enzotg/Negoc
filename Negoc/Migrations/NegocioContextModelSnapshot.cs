﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Negoc.Data;

namespace Negoc.Migrations
{
    [DbContext(typeof(NegocioContext))]
    partial class NegocioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Negoc.Models.Categoria", b =>
                {
                    b.Property<long>("CategoriaId");

                    b.Property<int>("NivelId");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<string>("NombreSing")
                        .HasMaxLength(50);

                    b.Property<long?>("ParentId");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Negoc.Models.Color", b =>
                {
                    b.Property<long>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HexCode")
                        .HasMaxLength(20);

                    b.Property<string>("Nombre")
                        .HasMaxLength(30);

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Negoc.Models.Deporte", b =>
                {
                    b.Property<long>("DeporteId");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("DeporteId");

                    b.ToTable("Deporte");
                });

            modelBuilder.Entity("Negoc.Models.Genero", b =>
                {
                    b.Property<byte>("GeneroId");

                    b.Property<string>("Nombre");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("Negoc.Models.Marca", b =>
                {
                    b.Property<long>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("MarcaId");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("Negoc.Models.ProdImagen", b =>
                {
                    b.Property<long>("ProdImagenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageMimeType");

                    b.Property<string>("Nombre");

                    b.Property<long>("ProductoId");

                    b.HasKey("ProdImagenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProdImagen");
                });

            modelBuilder.Entity("Negoc.Models.Producto", b =>
                {
                    b.Property<long>("ProductoId");

                    b.Property<long>("CategoriaId");

                    b.Property<long>("ColorId");

                    b.Property<long>("DeporteId");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100);

                    b.Property<float>("DescuentoPorc");

                    b.Property<string>("Detalle")
                        .HasMaxLength(2000);

                    b.Property<byte>("GeneroId");

                    b.Property<long>("MarcaId");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<double>("Precio");

                    b.Property<double>("PrecioLista");

                    b.Property<string>("PrecioStr")
                        .HasMaxLength(30);

                    b.Property<long>("TalleId");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ColorId");

                    b.HasIndex("DeporteId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Negoc.Models.ProdImagen", b =>
                {
                    b.HasOne("Negoc.Models.Producto")
                        .WithMany("Imagenes")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Negoc.Models.Producto", b =>
                {
                    b.HasOne("Negoc.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Negoc.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Negoc.Models.Deporte", "Deporte")
                        .WithMany()
                        .HasForeignKey("DeporteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Negoc.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Negoc.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
