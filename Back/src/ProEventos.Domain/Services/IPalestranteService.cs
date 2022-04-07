using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Response.Palestrante;

namespace ProEventos.Domain.Services
{
    public interface IPalestranteService
    {
        Task<IEnumerable<PalestranteResponse>> GetAll(bool includeEvento);
        Task<PalestranteResponse> GetById(int id, bool includeEvento);
        Task<IEnumerable<PalestranteResponse>> GetByNome(string nome, bool includeEvento);
    }
}