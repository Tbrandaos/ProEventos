using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Response.Evento;
using ProEventos.Domain.Request.Evento;
using ProEventos.Domain.Services;
using ProEventos.Infra.Entities;

namespace ProEventos.Infra.Services
{
    public class EventoService : IEventoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

       public EventoService(DataContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }

        public async Task<AddEventoRequest> Create(AddEventoRequest request)
        {
            try
            {
                var entity = _mapper.Map<Evento>(request);

                _context.Eventos.Add(entity);
                await _context.SaveChangesAsync();

                request.Id = entity.Id;

                return request;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetEventoResponse>> GetAll(bool includePalestrante = false)
        {
            try
            {
                IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

                if(includePalestrante)
                {
                    query = query
                        .Include(a => a.PalestrantesEventos)
                        .ThenInclude(pa => pa.Palestrante);
                }
                    
                query = query.OrderBy(a => a.Id);

                var eventos = await query.ToListAsync();

                return _mapper.Map<List<GetEventoResponse>>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetEventoResponse> GetById(int id,bool includePalestrante = false)
        {
            try
            {
                IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

                if(includePalestrante)
                {
                    query = query
                        .Include(a => a.PalestrantesEventos)
                        .ThenInclude(pa => pa.Palestrante);
                }
                    
                query = query
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == id);

                var evento = await query.FirstOrDefaultAsync();
                
                if(evento == null)
                    throw new Exception("Evento não encontrado para o Id: " + id);

                return _mapper.Map<GetEventoResponse>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }

        public async Task<IEnumerable<GetEventoResponse>> GetByTema(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

            if(includePalestrante)
            {
                query = query
                    .Include(a => a.PalestrantesEventos)
                    .ThenInclude(pa => pa.Palestrante);
            }
                    
            query = query
                .OrderBy(a => a.Id)
                .Where(a => a.Tema.ToLower().Contains(tema.ToLower()));

            var eventos = await query.ToListAsync();
                
            return _mapper.Map<List<GetEventoResponse>>(eventos);
        }
    }
}