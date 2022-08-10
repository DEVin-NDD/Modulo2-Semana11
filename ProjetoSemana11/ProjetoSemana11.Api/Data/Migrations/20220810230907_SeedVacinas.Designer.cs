﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoSemana11.Data;

#nullable disable

namespace ProjetoSemana11.Api.Data.Migrations
{
    [DbContext(typeof(ProjetoDbContext))]
    [Migration("20220810230907_SeedVacinas")]
    partial class SeedVacinas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoSemana11.Models.CarteiraTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("PisPasep")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("CarteirasTrabalho", (string)null);
                });

            modelBuilder.Entity("ProjetoSemana11.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("ProjetoSemana11.Models.ClienteVacina", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.HasKey("ClienteId", "VacinaId");

                    b.HasIndex("VacinaId");

                    b.ToTable("ClientesVacinas", (string)null);
                });

            modelBuilder.Entity("ProjetoSemana11.Models.Exame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoTuss")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Exames", (string)null);
                });

            modelBuilder.Entity("ProjetoSemana11.Models.Vacina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NumeroDoses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Vacinas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Gripe",
                            NumeroDoses = 1
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Tétano",
                            NumeroDoses = 1
                        });
                });

            modelBuilder.Entity("ProjetoSemana11.Models.CarteiraTrabalho", b =>
                {
                    b.HasOne("ProjetoSemana11.Models.Cliente", "Cliente")
                        .WithOne("CarteiraTrabalho")
                        .HasForeignKey("ProjetoSemana11.Models.CarteiraTrabalho", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ProjetoSemana11.Models.ClienteVacina", b =>
                {
                    b.HasOne("ProjetoSemana11.Models.Cliente", "Cliente")
                        .WithMany("Vacinas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetoSemana11.Models.Vacina", "Vacina")
                        .WithMany()
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("ProjetoSemana11.Models.Exame", b =>
                {
                    b.HasOne("ProjetoSemana11.Models.Cliente", "Cliente")
                        .WithMany("Exames")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ProjetoSemana11.Models.Cliente", b =>
                {
                    b.Navigation("CarteiraTrabalho");

                    b.Navigation("Exames");

                    b.Navigation("Vacinas");
                });
#pragma warning restore 612, 618
        }
    }
}
