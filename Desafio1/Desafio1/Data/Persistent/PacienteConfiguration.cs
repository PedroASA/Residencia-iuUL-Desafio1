﻿using Desafio1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio1.Data.Persistent
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder
                .Ignore(p => p.AgendamentoFuturo);

            builder
                .Property(p => p.Nome)
                .IsRequired();

            builder
                .Property(p => p.Cpf)
                .IsRequired();
        }
    }
}