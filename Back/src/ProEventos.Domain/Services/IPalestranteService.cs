using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Response.Palestrante;

namespace ProEventos.Domain.Services
{
    public interface IPalestranteService
    {
        Task<IEnumerable<GetPalestranteResponse>> GetAll(bool includeEvento);
        Task<GetPalestranteResponse> GetById(int id, bool includeEvento);
        Task<IEnumerable<GetPalestranteResponse>> GetByNome(string nome, bool includeEvento);
    }
}