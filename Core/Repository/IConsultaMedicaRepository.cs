
using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Repository
{
    public interface IConsultaMedicaRepository
    {
        Task<IEnumerable<ConsultaModel>> ConsultaMedicas();
        Task<ConsultaModel> ConsultaMedicasById(int id);
        Task<ConsultaModel> Salvar(ConsultaMedicaDto consulta);

        Task<ConsultaModel> AlterarConsulta(ConsultaMedicaAtualizarDto consultaMedicaAtualizar);
        Task<bool> ExluirConsulta(int id);

        Task<IEnumerable<ConsultaModel>> BuscarConsultasComDapper();
    }
}
