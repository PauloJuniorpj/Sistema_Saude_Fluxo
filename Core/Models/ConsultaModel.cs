using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Core.Models;

namespace FluxoMedicoTesteNeoApp.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }

        public PacienteModel Paciente { get; set; }
        public MedicoModel Medico {  get; set; }
        public string Cpf { get; set; }

        public string Nome { get; set; }
       
        public int? PacienteId { get; set; }

        public int? MedicoId { get; set; }

        public string Diagnostico { get; set; }
        public DateTime? DataConsulta { get; set; }

        public ConsultaMedicaDto Consulta() { 
            ConsultaMedicaDto consulta = new ConsultaMedicaDto();
            consulta.CpfPaciente = Paciente.Cpf;
            consulta.Diagnostico = Diagnostico;
            consulta.NomePaciente = Paciente.Nome;
            consulta.NomeMedico = Medico.Nome;
            return consulta;
        }

        public ConsultaModel (ConsultaMedicaDto consultaMedicaDto) {
            Paciente.Nome = consultaMedicaDto.NomePaciente;
            Paciente.Cpf = consultaMedicaDto.CpfPaciente;
            Medico.Nome = consultaMedicaDto.NomeMedico;
            Diagnostico = consultaMedicaDto.Diagnostico;
            DataConsulta = DateTime.UtcNow;
        }

        public ConsultaModel(){ }
    }
}
