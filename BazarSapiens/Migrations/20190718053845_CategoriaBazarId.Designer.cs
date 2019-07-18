﻿// <auto-generated />
using System;
using BazarSapiens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BazarSapiens.Migrations
{
    [DbContext(typeof(BazarContext))]
    [Migration("20190718053845_CategoriaBazarId")]
    partial class CategoriaBazarId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("BazarSapiens.Models.Banner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BazarId");

                    b.Property<string>("Imagem")
                        .HasMaxLength(20);

                    b.Property<int>("Ordem");

                    b.Property<string>("Situacao")
                        .HasMaxLength(10);

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("BazarSapiens.Models.Bazar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Fim");

                    b.Property<DateTime>("Inicio");

                    b.Property<string>("Instagram")
                        .HasMaxLength(100);

                    b.Property<string>("Logotipo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Regras");

                    b.Property<int>("Situacao");

                    b.Property<string>("Twitter")
                        .HasMaxLength(100);

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.ToTable("Bazares");
                });

            modelBuilder.Entity("BazarSapiens.Models.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BazarId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BazarSapiens.Models.Colaborador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BazarId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100);

                    b.Property<string>("Foto")
                        .HasMaxLength(20);

                    b.Property<string>("Instagram")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Ordem");

                    b.Property<string>("Twitter")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("BazarSapiens.Models.Lance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<long?>("ProdutoId");

                    b.Property<string>("Usuario")
                        .HasMaxLength(255);

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Lances");
                });

            modelBuilder.Entity("BazarSapiens.Models.Noticia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long?>("BazarId");

                    b.Property<string>("Corpo")
                        .IsRequired();

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("FotoPrincipal");

                    b.Property<string>("Resumo")
                        .IsRequired();

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

                    b.Property<long?>("BazarId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Logotipo")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Ordem");

                    b.Property<string>("Url");

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("BazarSapiens.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("BazarId");

                    b.Property<long?>("CategoriaId");

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

                    b.Property<string>("UsuarioUltimoLance")
                        .HasMaxLength(14);

                    b.Property<decimal>("ValorAtual");

                    b.Property<decimal>("ValorInicial");

                    b.Property<decimal>("ValorLance");

                    b.Property<int>("Visualizacoes");

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("BazarSapiens.Models.Testemunho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Autor");

                    b.Property<long?>("BazarId");

                    b.Property<string>("Cargo");

                    b.Property<string>("Foto")
                        .HasMaxLength(20);

                    b.Property<int>("Ordem");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BazarId");

                    b.ToTable("Testemunhos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BazarSapiens.Models.Usuario", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Cpf");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("BazarSapiens.Models.Banner", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Categoria", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Colaborador", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Lance", b =>
                {
                    b.HasOne("BazarSapiens.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Noticia", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Parceiro", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Produto", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany("Produtos")
                        .HasForeignKey("BazarId");

                    b.HasOne("BazarSapiens.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("BazarSapiens.Models.Testemunho", b =>
                {
                    b.HasOne("BazarSapiens.Models.Bazar", "Bazar")
                        .WithMany()
                        .HasForeignKey("BazarId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
