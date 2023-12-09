using FluxoMedicoTesteNeoApp.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluxoMedicoTesteNeoApp.Controllers
{
    public class MedicoControlle : ControllerBase
    {   
        [HttpPost("/cadastrarMedico")]
        public async Task<IActionResult> CriarConsulta(ConsultaMedicaDto consultaMedicaDto)
        {
            return null;
        }

    }
}
