﻿// <auto-generated />
using System;
using Cine_Net.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cine_Net.Infra.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20230616035116_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cine_Net.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categorias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinema");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEstudante")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Equipamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Itens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AtorPrincipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Classificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diretor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Duracao")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Ingresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("SessaoId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("SessaoId");

                    b.ToTable("Ingresso");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("EquipamentosId")
                        .HasColumnType("int");

                    b.Property<bool>("Is3D")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("PrecoIngresso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FilmeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("SalaId");

                    b.ToTable("Sessao");
                });

            modelBuilder.Entity("FilmeCategoria", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("FilmeCategoria");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Equipamentos", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Sala", "Salas")
                        .WithMany("Equipamentos")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Ingresso", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Cine_Net.Domain.Entities.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("SessaoId");

                    b.Navigation("Cliente");

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sala", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Cinema", null)
                        .WithMany("Salas")
                        .HasForeignKey("CinemaId");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sessao", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeId");

                    b.HasOne("Cine_Net.Domain.Entities.Sala", "Sala")
                        .WithMany("Sessao")
                        .HasForeignKey("SalaId");

                    b.Navigation("Filme");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("FilmeCategoria", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine_Net.Domain.Entities.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Cinema", b =>
                {
                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sala", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("Sessao");
                });
#pragma warning restore 612, 618
        }
    }
}