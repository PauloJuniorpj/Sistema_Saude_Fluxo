﻿using AutoMapper;
using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Repository;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FluxoMedicoTesteNeoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaMedicaController : ControllerBase
    {
        private readonly IConsultaMedicaRepository _consultaMedicaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public ConsultaMedicaController(IConsultaMedicaRepository consultaMedicaRepository, IMapper mapper, 
            IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {   
            _mapper = mapper;
            _consultaMedicaRepository = consultaMedicaRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultasMedicas()
        {
            IEnumerable<ConsultaModel> consultas = await _consultaMedicaRepository.ConsultaMedicas();
            return Ok(consultas);
        }

        // Consulta pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaMedicaById(int id)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var consultas = await _consultaMedicaRepository.ConsultaMedicasById(id);

            return consultas != null ? Ok(consultas) : NotFound("Consultas não existe na base de dados");
        }

        [HttpPost("/cadastrarConsulta")]
        public async Task<IActionResult> CriarConsulta(int idPaciente, int idMedico, ConsultaMedicaDto consultaMedicaDto)
        {
            if (idPaciente <= 0 && idMedico <= 0) return BadRequest("Medico é Paciente não encontrado na base de dados");

            _ = await _pacienteRepository.BuscarPacienteById(idPaciente);

           _ = await _medicoRepository.BuscarMedicoById(idMedico);

            if (consultaMedicaDto == null) return BadRequest("Dados Invalidos");
            var consultaModel = await _consultaMedicaRepository.Salvar(consultaMedicaDto);

            return consultaModel != null ? Ok(consultaModel) : NotFound("Ouve erro na Cadastramento da Consulta");
        }
        
       
        [HttpPut("/atualizarConsulta/{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id,ConsultaMedicaAtualizarDto atualizarDto)
        {
            if  (id<= 0) return BadRequest("Consulta não encontrada");

            var consultas = await _consultaMedicaRepository.ConsultaMedicasById(id);

            if (consultas == null) return NotFound("Consulta não encontrada na base de dados");

            var consultaAtualizada = await _consultaMedicaRepository.AlterarConsulta(atualizarDto);

            return consultaAtualizada != null ? Ok("Consulta atualizada com sucesso") : NotFound("Erro ao atualizar consulta");
        }

        [HttpDelete("/excluirConsulta/{id}")]
        public async Task<IActionResult> ExluirConsulta(int id)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var consulta = await _consultaMedicaRepository.ExluirConsulta(id);
            return consulta != false ? Ok("Consulta excluida com sucesso") : NotFound("não tem essa consulta na base de dados");
        }
    }
}
