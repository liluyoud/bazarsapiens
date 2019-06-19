﻿// <auto-generated />
using System;
using BazarSapiens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BazarSapiens.Migrations
{
    [DbContext(typeof(BazarContext))]
    partial class BazarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("BazarSapiens.Models.Bazar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("Fim");

                    b.Property<DateTime>("Inicio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Situacao");

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.ToTable("Bazares");
                });

            modelBuilder.Entity("BazarSapiens.Models.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BazarSapiens.Models.Noticia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("BazarId");

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("FotoPrincipal");

                    b.Property<string>("Tags");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("TotalFotos");

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("BazarSapiens.Models.Parceiro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BazarId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("BazarSapiens.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BazarId");

                    b.Property<long>("CategoriaId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("FotoPrincipal");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("QuantidadeLances");

                    b.Property<int>("TotalFotos");

                    b.Property<decimal>("ValorAtual");

                    b.Property<decimal>("ValorInicial");

                    b.Property<decimal>("ValorLance");

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("BazarSapiens.Models.Noticia", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BazarSapiens.Models.Parceiro", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BazarSapiens.Models.Produto", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany("Produtos")
                        .HasForeignKey("BazarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BazarSapiens.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
