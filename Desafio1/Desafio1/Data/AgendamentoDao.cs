﻿using Desafio1.Models;
using System.Collections.Generic;
using System;
using Desafio1.Data.Entity;

namespace Desafio1.Data.NonPersistent
{
    // Agendamento Data Access Object
    public class AgendamentoDao
    {
        // Referência ao contexto de Dados
        private readonly IConsultorio _consultorio;

        public AgendamentoDao(IConsultorio consultorio) {
            _consultorio = consultorio;
        }

        public AgendamentoDao() {
            // _consultorio = new DefaultConsultorio();
            _consultorio = new EntityConsultorio(PostgresConsultorioContext.Build());
        //    _consultorio = new EntityConsultorio(new EntityContext());
        }

        public void Add(Agendamento a)
        {
            if(!_consultorio.CpfExists(a.CpfDoPaciente))
                throw new Agendamento.InvalidAgendamentoException("Cpf do Paciente informado não possui cadastro");

            if (_consultorio.IsAgendamentoCadastrado(a))
                throw new Agendamento.InvalidAgendamentoException("Horário já preenchido");

            // Preencher campo Agendamento Futuro do Paciente
            var tmp = _consultorio.GetPacienteByCpf(a.CpfDoPaciente);
            try
            {
                tmp.AgendamentoFuturo = a;
            }catch(Exception)
            {
                throw new Agendamento.InvalidAgendamentoException("Paciente Informado já possui agendamento futuro");
            }
            // Preencher campo Paciente do Agendamento
            a.Paciente = tmp;

            // Adicionar Agendamento ao contexto de Dados
            _consultorio.AddAgendamento(a);
        }

        public void Delete(ulong cpf, DateTime dataConsulta, ushort horaInicial)
        {
            if(!Agendamento.IsDateFuture(dataConsulta, horaInicial))
                throw new Agendamento.InvalidAgendamentoException("Agendamento não é data futura e, portanto, não pode ser cancelado");

            if (!_consultorio.DeleteAgendamento(cpf, dataConsulta, horaInicial))
                throw new Agendamento.InvalidAgendamentoException("Agendamento não cadastrado");

        }

        public IEnumerable<Agendamento> GetAll()
        {
            return _consultorio.GetAllAgendamentos();
        }
    }
}