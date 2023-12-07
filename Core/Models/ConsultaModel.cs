using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;

namespace FluxoMedicoTesteNeoApp.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }
       // public List<PacienteModel> pacientes { get; set; }
        public string Diagnostico { get; set; }
        public DateTime? DataConsulta { get; set; }

        public ConsultaMedicaDto Consulta() { 
            ConsultaMedicaDto consulta = new ConsultaMedicaDto();
            consulta.Cpf = Cpf;
            consulta.Diagnostico = Diagnostico;
            consulta.Nome = Nome;
            return consulta;
        }

        public ConsultaModel (ConsultaMedicaDto consultaMedicaDto) {
            Nome = consultaMedicaDto.Nome;
            Cpf = consultaMedicaDto.Cpf;
            Diagnostico = consultaMedicaDto.Diagnostico;
            DataConsulta = DateTime.UtcNow;
        }

        public ConsultaModel(){ }
    }
}
