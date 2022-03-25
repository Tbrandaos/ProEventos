using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Response.Evento;

namespace ProEventos.Domain.Services
{
    public interface IEventoService
    {
        Task<IEnumerable<GetEventoResponse>> GetAll(bool includePalestrante);
        Task<GetEventoResponse> GetById(int id, bool includePalestrante);
        Task<IEnumerable<GetEventoResponse>> GetByTema(string tema, bool includePalestrantes);
    }
}