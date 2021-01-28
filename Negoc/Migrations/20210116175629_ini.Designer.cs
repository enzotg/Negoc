﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Negoc.Data;

namespace Negoc.Migrations
{
    [DbContext(typeof(NegocioContext))]
    [Migration("20210116175629_ini")]
    partial class ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Nombre");

                    b.Property<long?>("ParentId");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
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
                    b.Property<long>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoriaId");

                    b.Property<byte>("ColorId");

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

                    b.HasOne("Negoc.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
