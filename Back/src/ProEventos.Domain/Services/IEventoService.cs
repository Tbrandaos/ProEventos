using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Request.Evento;
using ProEventos.Domain.Response.Evento;

namespace ProEventos.Domain.Services
{
    public interface IEventoService
    {
        Task<AddEventoRequest> Create(AddEventoRequest request);
        Task<IEnumerable<GetEventoResponse>> GetAll(bool includePalestrante);
        Task<GetEventoResponse> GetById(int id, bool includePalestrante);
        Task<IEnumerable<GetEventoResponse>> GetByTema(string tema, bool includePalestrante);
    }
}