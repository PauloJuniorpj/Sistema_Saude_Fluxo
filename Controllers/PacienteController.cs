using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Core.Repository;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluxoMedicoTesteNeoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaPacientes()
        {
            IEnumerable<PacienteModel> pacientes = await _pacienteRepository.ConsultaPacientes();
            return Ok(pacientes);
        }
        [HttpGet("/buscarPacientePorId/{id}")]
        public async Task<IActionResult> BuscarPacienteById(int id)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var paciente = await _pacienteRepository.BuscarPacienteById(id);
            return paciente != null ? Ok(paciente) : NotFound("paciente não encontrado na base de dados");
        }

        [HttpPut("/atualizarPaciente/{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, PacienteAtualizadoDto pacienteAtualizadoDto)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var paciente = await _pacienteRepository.BuscarPacienteById(id);

            if (paciente == null) return NotFound("Consulta não encontrada na base de dados");

            var pacienteAtualizado = await _pacienteRepository.AlterarPacientes(pacienteAtualizadoDto);

            return pacienteAtualizado != null ? Ok("Paciente atualizado com sucesso") : NotFound("Erro ao atualizar paciente");
        }

        [HttpPost("/cadastrarPacientes")]
        public async Task<IActionResult> cadastrarPacientes(PacienteDto pacienteDto)
        {
            if (pacienteDto == null) return BadRequest("Dados invalidos");
            var paciente = await _pacienteRepository.Salvar(pacienteDto);
            return paciente != null ? Ok("Cadastrado com sucesso") : NotFound("Ouve um erro no Cadastramento do Paciente");
        }

        [HttpDelete("/excluirPaciente/{id}")]
        public async Task<IActionResult> ExluirPaciente(int id)
        {
            if (id <= 0) return BadRequest("Paciente não encontrada");

            var paciente = await _pacienteRepository.ExluirPaciente(id);
            return paciente != false ? Ok("Paciente excluido com sucesso") : NotFound("não tem esse paciente na base de dados");
        }
        
    }
}
