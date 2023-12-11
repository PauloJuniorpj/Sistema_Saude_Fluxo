namespace FluxoMedicoTesteNeoApp.Core.Dtos
{
    public class ConsultaMedicaAtualizarDto
    {
        public int Id { get; set; }

        public string NomePaciente { get; set; }

        public string CpfPaciente { get; set; }

        public string NomeMedico { get; set; }
        // public List<PacienteModel> pacientes { get; set; }
        public string Diagnostico { get; set; }
       

    }
}
