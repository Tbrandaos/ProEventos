using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Response.Evento;
using ProEventos.Domain.Response.Palestrante;
using ProEventos.Domain.Services;

namespace ProEventos.Infra.Services
{
    public class PalestranteService : IPalestranteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

       public PalestranteService(DataContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }

        public async Task<IEnumerable<GetPalestranteResponse>> GetAll(bool includeEvento)
        {
            try
            {
                var palestrantes = await _context.Palestrantes.ToListAsync();
                return _mapper.Map<List<GetPalestranteResponse>>(palestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetPalestranteResponse> GetById(int id, bool includeEvento)
        {
            try
            {
                var palestrante =  await _context.Palestrantes.FirstOrDefaultAsync(b => b.Id == id);
                
                if(palestrante == null)
                    throw new Exception("Palestrante não encontrado para o Id: " + id);

                return _mapper.Map<GetPalestranteResponse>(palestrante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<IEnumerable<GetPalestranteResponse>> GetByNome(string nome, bool includeEvento)
        {
            var palestrantes = await _context.Palestrantes.Where(a => a.Nome == nome).ToListAsync();
            return _mapper.Map<List<GetPalestranteResponse>>(palestrantes);
        }
    }
}