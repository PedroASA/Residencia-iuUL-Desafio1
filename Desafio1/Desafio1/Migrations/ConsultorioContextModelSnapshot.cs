﻿// <auto-generated />
using System;
using Desafio1.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio1.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class ConsultorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desafio1.Models.Agendamento", b =>
                {
                    b.Property<decimal>("CpfDoPaciente")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("DataDaConsulta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HorarioInicial")
                        .HasColumnType("integer");

                    b.Property<int>("HorarioFinal")
                        .HasColumnType("integer");

                    b.HasKey("CpfDoPaciente", "DataDaConsulta", "HorarioInicial");

                    b.HasIndex("CpfDoPaciente")
                        .IsUnique();

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Desafio1.Models.Paciente", b =>
                {
                    b.Property<decimal>("Cpf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Cpf");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Desafio1.Models.Agendamento", b =>
                {
                    b.HasOne("Desafio1.Models.Paciente", "Paciente")
                        .WithOne("AgendamentoFuturo")
                        .HasForeignKey("Desafio1.Models.Agendamento", "CpfDoPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Desafio1.Models.Paciente", b =>
                {
                    b.Navigation("AgendamentoFuturo");
                });
#pragma warning restore 612, 618
        }
    }
}
