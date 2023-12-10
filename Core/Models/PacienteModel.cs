using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Enums;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.Models
{
    public class PacienteModel
    {
        private PacienteDto pacienteDto;

       

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade {  get; set; }

        public DateTime? DataCadastroPaciente { get; set; }

        public virtual List<ConsultaModel> Consultas { get; set; }

        public virtual List<MedicoModel> Medicos { get; set; }

        public PerfilEnum Perfil { get; set; }

        public PacienteModel(PacienteDto pacienteDto)
        {
            Nome = pacienteDto.Nome;
            Cpf = pacienteDto.Cpf;
            Idade = pacienteDto.Idade;
            DataCadastroPaciente = DateTime.UtcNow;
        }

        public PacienteModel()
        {

        }
    }
}
