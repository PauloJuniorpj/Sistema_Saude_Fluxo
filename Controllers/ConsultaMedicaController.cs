using AutoMapper;
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
        private readonly IMapper _mapper;
        public ConsultaMedicaController(IConsultaMedicaRepository consultaMedicaRepository, IMapper mapper)
        {   
            _mapper = mapper;
            _consultaMedicaRepository = consultaMedicaRepository;
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
        public async Task<IActionResult> CriarConsulta(ConsultaMedicaDto consultaMedicaDto)
        {
            if (consultaMedicaDto == null) return BadRequest("Dados Invalidos");
            var consultaModel = await _consultaMedicaRepository.Salvar(consultaMedicaDto);
            return consultaModel != null ? Ok(consultaModel.Consulta()) : NotFound("Ouve erro na Cadastramento da Consulta");
        }
    }
}
