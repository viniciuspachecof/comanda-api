﻿// <auto-generated />
using ApiComanda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiComanda.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200722220835_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ApiComanda.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("descricao")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("categoria");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descricao = "Alimento"
                        });
                });

            modelBuilder.Entity("ApiComanda.Models.Comanda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("numero")
                        .HasColumnType("integer");

                    b.Property<int>("qtde")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("comanda");

                    b.HasData(
                        new
                        {
                            id = 1,
                            numero = 1,
                            qtde = 1
                        });
                });

            modelBuilder.Entity("ApiComanda.Models.ComandaProduto", b =>
                {
                    b.Property<int>("produtoId")
                        .HasColumnType("integer");

                    b.Property<int>("comandaId")
                        .HasColumnType("integer");

                    b.HasKey("produtoId", "comandaId");

                    b.HasIndex("comandaId");

                    b.ToTable("comandaproduto");

                    b.HasData(
                        new
                        {
                            produtoId = 1,
                            comandaId = 1
                        });
                });

            modelBuilder.Entity("ApiComanda.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("categoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("observacao")
                        .HasColumnType("text");

                    b.Property<double>("valor")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.HasIndex("categoriaId");

                    b.ToTable("produto");

                    b.HasData(
                        new
                        {
                            id = 1,
                            categoriaId = 1,
                            nome = "Pão",
                            observacao = "Doce",
                            valor = 1.23
                        });
                });

            modelBuilder.Entity("ApiComanda.Models.ComandaProduto", b =>
                {
                    b.HasOne("ApiComanda.Models.Comanda", "comanda")
                        .WithMany("comandasprodutos")
                        .HasForeignKey("comandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiComanda.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiComanda.Models.Produto", b =>
                {
                    b.HasOne("ApiComanda.Models.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}