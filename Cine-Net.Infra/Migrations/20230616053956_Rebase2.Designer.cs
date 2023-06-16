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
    [Migration("20230616053956_Rebase2")]
    partial class Rebase2
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categorias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngressoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEstudante")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
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

                    b.Property<int>("SessaoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
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

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("SessaoId")
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

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("EquipamentosId")
                        .HasColumnType("int");

                    b.Property<bool>("Is3D")
                        .HasColumnType("bit");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("PrecoIngresso")
                        .HasColumnType("float");

                    b.Property<int>("SessaoId")
                        .HasColumnType("int");

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

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int>("IngressoId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("SalaId");

                    b.ToTable("Sessao");
                });

            modelBuilder.Entity("FilmeCategoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "FilmeId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FilmeId");

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
                        .WithMany("Ingresso")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine_Net.Domain.Entities.Sessao", "Sessao")
                        .WithMany("Ingresso")
                        .HasForeignKey("SessaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sala", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Cinema", "Cinema")
                        .WithMany("Salas")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sessao", b =>
                {
                    b.HasOne("Cine_Net.Domain.Entities.Filme", "Filme")
                        .WithMany("Sessao")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cine_Net.Domain.Entities.Sala", "Sala")
                        .WithMany("Sessao")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

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

            modelBuilder.Entity("Cine_Net.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Ingresso");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Filme", b =>
                {
                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sala", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("Cine_Net.Domain.Entities.Sessao", b =>
                {
                    b.Navigation("Ingresso");
                });
#pragma warning restore 612, 618
        }
    }
}
