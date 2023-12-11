using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Core.Repository;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluxoMedicoTesteNeoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MedicoControlle : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoControlle(MedicoRepository medicicoRepository)
        {
            _medicoRepository = medicicoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaMedicos()
        {
            IEnumerable<MedicoModel> medicos = await _medicoRepository.ConsultarMedico();
            return Ok(medicos);
        }

        [HttpGet("/buscarPorId")]
        public async Task<IActionResult> ConsultarMedicoById(int id)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");
           var medico = await _medicoRepository.BuscarMedicoById(id);

            return medico != null ? Ok(medico) : NotFound("Medico não encontrado na base de dados");
        }

        [HttpPost("/cadastrarMedico")]
        public async Task<IActionResult> CadastrarMedico(MedicoDto medicoDto)
        {
            if (medicoDto == null) return BadRequest("Dados invalidos");
            var medico = await _medicoRepository.Salvar(medicoDto);
            return medico != null ? Ok("Cadastrado com sucesso ") : NotFound("Ouve um erro no Cadastro do Medico");

        }

        [HttpPut("/atualizarConsulta/{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id, MedicoAtualizadoDto medicoAtualizado)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var medico = await _medicoRepository.BuscarMedicoById(id);

            if (medico == null) return NotFound("Consulta não encontrada na base de dados");

            var cadastroMedicoAtualizado = await _medicoRepository.AlterarDadosMedico(medicoAtualizado);

            return cadastroMedicoAtualizado != null ? Ok("Cadastro atualizado com sucesso") : NotFound("Erro ao atualizar consulta");
        }

        [HttpDelete("/excluirPaciente")]
        public async Task<IActionResult> ExluirPaciente(int id)
        {
            if (id <= 0) return BadRequest("Consulta não encontrada");

            var medico = await _medicoRepository.ExcluirMedico(id);
            return medico != false ? Ok("Paciente excluido com sucesso") : NotFound("não tem esse paciente na base de dados");
        }

    }
}
