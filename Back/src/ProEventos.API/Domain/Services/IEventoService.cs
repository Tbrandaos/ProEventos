using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.API.Domain.Response;

namespace ProEventos.API.Domain.Services
{
    public interface IEventoService
    {
        Task<IEnumerable<GetEventoResponse>> GetAll();
        Task<GetEventoResponse> GetById(int id);
    }
}