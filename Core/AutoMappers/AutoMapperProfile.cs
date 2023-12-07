using AutoMapper;
using FluxoMedicoTesteNeoApp.Core.Dtos;
using FluxoMedicoTesteNeoApp.Models;

namespace FluxoMedicoTesteNeoApp.Core.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            //Criando Relacionamento do Mapper dos Dtos com minha Model
            CreateMap<ConsultaMedicaDto, ConsultaModel>();

        }
    }
}
