using AutoMapper;
using ProEventos.API.Domain.Response;
using ProEventos.API.Infra.Entities;

namespace ProEventos.API.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMapEvento();
        }

        private static void CreateMapEvento(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<GetEventoResponse, Evento>().ReverseMap();
        }
    }
}