using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Response.Palestrante;
using ProEventos.Domain.Services;
using ProEventos.Infra.Context;
using ProEventos.Infra.Entities;

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

       public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);       
            }   
        }

        public async Task<IEnumerable<PalestranteResponse>> GetAll(bool includeEvento = false)
        {
            try
            {
                 IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(a => a.RedesSociais);

                if(includeEvento)
                {
                    query = query
                        .Include(a => a.PalestrantesEventos)
                        .ThenInclude(pa => pa.Evento);
                }
                    
                query = query.OrderBy(a => a.Id);

                var palestrantes = await query.ToListAsync();
                return _mapper.Map<List<PalestranteResponse>>(palestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PalestranteResponse> GetById(int id, bool includeEvento = false)
        {
            try
            {
                IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(a => a.RedesSociais);

                if(includeEvento)
                {
                    query = query
                        .Include(a => a.RedesSociais)
                        .ThenInclude(pa => pa.Evento);
                }
                    
                query = query
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == id);

                var palestrante = await query.FirstOrDefaultAsync();
                
                if(palestrante == null)
                    throw new Exception("Palestrante não encontrado para o Id: " + id);

                return _mapper.Map<PalestranteResponse>(palestrante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<IEnumerable<PalestranteResponse>> GetByNome(string nome, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(a => a.RedesSociais);

            if(includeEvento)
            {
                query = query
                    .Include(a => a.PalestrantesEventos)
                    .ThenInclude(pa => pa.Evento);
            }
                    
            query = query
                .OrderBy(a => a.Id)
                .Where(a => a.Nome.ToLower().Contains(nome.ToLower()));

            var palestrantes = await query.ToListAsync();            
            return _mapper.Map<List<PalestranteResponse>>(palestrantes);
        }
    }
}