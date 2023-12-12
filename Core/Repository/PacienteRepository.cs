using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;
using FluxoMedicoTesteNeoApp.Data;
using FluxoMedicoTesteNeoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly BancoContext _bancoContext;
        public PacienteRepository(BancoContext bancoContext ) {
            _bancoContext = bancoContext;
        }

        public async Task<PacienteModel> BuscarPacienteById(int? id)
        {   
            if(id == null)
            {
                throw new System.Exception("Verifique o Id passado se está correto!");

            }
            return await _bancoContext.Pacientes.Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PacienteModel>> ConsultaPacientes()
        {
            return await _bancoContext.Pacientes.ToListAsync();
        }

        public async Task<PacienteModel> Salvar(PacienteDto pacienteDto)
        {
            if(pacienteDto == null)
            {
                throw new SystemException("Houve um erro nas informações do Paciente");
            }
            PacienteModel pacienteModel = new PacienteModel(pacienteDto);
            pacienteModel.Perfil = Enums.PerfilEnum.Paciente;
            await _bancoContext.Pacientes.AddAsync(pacienteModel);
            await _bancoContext.SaveChangesAsync();
            return pacienteModel;
        }

        public async Task<bool> ExluirPaciente(int id)
        {
            PacienteModel paciente = await BuscarPacienteById(id);
            if (paciente == null)
            {
                throw new System.Exception("Houve um erro na exlusao do usuário");
            }

            _bancoContext.Pacientes.Remove(paciente);
            _bancoContext.SaveChanges();

            return true;
        }

        public async Task<PacienteModel> AlterarPacientes(PacienteAtualizadoDto pacienteAtualizadoDto)
        {
            var paciente = new PacienteModel(pacienteAtualizadoDto);
            if (paciente == null)
            {
                throw new System.Exception("Houve um erro na atualozação da consulta!");
            }
            _bancoContext.Pacientes.Update(paciente);
            await _bancoContext.SaveChangesAsync();
            return paciente;
        }
    }
}
