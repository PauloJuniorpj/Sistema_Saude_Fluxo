﻿using Dapper;
using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Data;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public class ConsultaMedicaRepository : IConsultaMedicaRepository
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly BancoContext _bancoContext;

        //config pra usar o dapper exemplo
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ConsultaMedicaRepository(BancoContext bancoContext, 
            IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, 
            IConfiguration configuration, string connectionString)
        {
            _bancoContext = bancoContext;
            _pacienteRepository = pacienteRepository;
            _medicoRepository = medicoRepository;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("WebApiDatabase");
        }

        public async Task<IEnumerable<ConsultaModel>> ConsultaMedicas()
        {
            return await _bancoContext.ConsultasMedicas.ToListAsync();
        }

        public async Task<ConsultaModel> ConsultaMedicasById(int id)
        {
            return await _bancoContext.ConsultasMedicas.Where(x => x.Id == id) .FirstOrDefaultAsync(x => x.Id == id);
        }



        //Methodo de salvar CREATE
        public async Task<ConsultaModel> Salvar(ConsultaMedicaDto consulta)
        {   
            ConsultaModel model = new ConsultaModel(consulta);
            var idPaciente = model.PacienteId; 
            var idMedico  = model.MedicoId;
            var medico = await _medicoRepository.BuscarMedicoById(idMedico);
            var paciente = await _pacienteRepository.BuscarPacienteById(idPaciente);
            model.Paciente = paciente; 
            model.Medico = medico;

            // Toda vez que ele cadastra uma consulta ele vai gravar o medico e o paciente na tabela composta
            var medicopacientesSalvos = new MedicosPacientes();
            medicopacientesSalvos.PacienteId = paciente.Id;
            medicopacientesSalvos.MedicoId = medico.Id;
            // Toda vez que ele cadastra uma consulta ele vai gravar o medico e o paciente na tabela composta

            await _bancoContext.medicosPacientes.AddAsync(medicopacientesSalvos);
            await _bancoContext.ConsultasMedicas.AddAsync(model);
            await _bancoContext.SaveChangesAsync();
            return model;
        }

        public async Task<ConsultaModel> AlterarConsulta(ConsultaMedicaAtualizarDto consultaMedicaAtualizar)
        {
            var consultaAtualizada = new ConsultaModel(consultaMedicaAtualizar); 
            if(consultaAtualizada == null)  {
                throw new System.Exception("Houve um erro na atualozação da consulta!");
            }
            _bancoContext.ConsultasMedicas.Update(consultaAtualizada);
            await _bancoContext.SaveChangesAsync();
            return consultaAtualizada;
        }

        public async Task<bool> ExluirConsulta(int id)
        {
            ConsultaModel consulta = await ConsultaMedicasById(id);
            if (consulta == null)
            {
                throw new System.Exception("Houve um erro na exlusao do usuário");
            }

            _bancoContext.ConsultasMedicas.Remove(consulta);
            _bancoContext.SaveChanges();

            return true;
        }

        // Ultilização do Dapper pra querys customizadas
        public async Task<IEnumerable<ConsultaModel>> BuscarConsultasComDapper()
        {
            var sql = @"select 
		                ""Diagnostico"",
		                ""Pacientes"".""Nome""
                        from ""ConsultasMedicas""
                        inner join ""Pacientes"" On ""ConsultasMedicas"".""Id"" = ""Pacientes"".""Id""
                        where  ""Pacientes"".""Id"" = 2";
            using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryAsync<ConsultaModel>(sql);
            }
        }
    }
}
