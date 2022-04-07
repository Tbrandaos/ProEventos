using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Request.Evento;
using ProEventos.Domain.Response.Evento;

namespace ProEventos.Domain.Services
{
    public interface IEventoService
    {
        Task<EventoResponse> Create(EventoRequest request);
        Task<EventoResponse> Update(EventoRequest request);
        Task<int> Delete(int id);
        Task<IEnumerable<EventoResponse>> GetAll(bool includePalestrante);
        Task<EventoResponse> GetById(int id, bool includePalestrante);
        Task<IEnumerable<EventoResponse>> GetByTema(string tema, bool includePalestrante);
    }
}