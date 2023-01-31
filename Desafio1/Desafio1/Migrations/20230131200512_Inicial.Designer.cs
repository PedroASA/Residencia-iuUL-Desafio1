﻿// <auto-generated />
using System;
using Desafio1.Data.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio1.Migrations
{
    [DbContext(typeof(ConsultorioContext))]
    [Migration("20230131200512_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desafio1.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfDoPaciente")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf_do_paciente");

                    b.Property<DateTime>("DataDaConsulta")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_da_consulta");

                    b.Property<int>("HorarioFinal")
                        .HasColumnType("integer")
                        .HasColumnName("horario_final");

                    b.Property<int>("HorarioInicial")
                        .HasColumnType("integer")
                        .HasColumnName("horario_inicial");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("integer")
                        .HasColumnName("paciente_id");

                    b.HasKey("Id")
                        .HasName("pk_agendamentos");

                    b.HasIndex("PacienteId")
                        .HasDatabaseName("ix_agendamentos_paciente_id");

                    b.ToTable("agendamentos", (string)null);
                });

            modelBuilder.Entity("Desafio1.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_de_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_pacientes");

                    b.ToTable("pacientes", (string)null);
                });

            modelBuilder.Entity("Desafio1.Models.Agendamento", b =>
                {
                    b.HasOne("Desafio1.Models.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .HasConstraintName("fk_agendamentos_pacientes_paciente_id");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Desafio1.Models.Paciente", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}