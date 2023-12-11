using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;

namespace FluxoMedicoTesteNeoApp.Models
{
    public class ConsultaModel
    {
      
        public int Id { get; set; }

        public PacienteModel Paciente { get; set; }
        public MedicoModel Medico {  get; set; }  
        public int? PacienteId { get; set; }

        public int? MedicoId { get; set; }

        public string Diagnostico { get; set; }
        public DateTime? DataConsulta { get; set; }

        public ConsultaModel (ConsultaMedicaDto consultaMedicaDto) {
            Diagnostico = consultaMedicaDto.diagnostico;
            DataConsulta = DateTime.UtcNow;
        }

        public ConsultaModel(){ }

        public ConsultaModel(ConsultaMedicaAtualizarDto consultaMedicaAtualizar)
        {
            Diagnostico = consultaMedicaAtualizar.Diagnostico;
        }
    }
}
