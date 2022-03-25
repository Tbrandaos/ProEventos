using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Response.Evento;
using ProEventos.Domain.Services;

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

        public async Task<IEnumerable<GetEventoResponse>> GetAll(bool includePalestrante)
        {
            try
            {
                var eventos = await _context.Eventos.ToListAsync();
                return _mapper.Map<List<GetEventoResponse>>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetEventoResponse> GetById(int id,bool includePalestrante)
        {
            try
            {
                var evento =  await _context.Eventos.FirstOrDefaultAsync(b => b.Id == id);
                
                if(evento == null)
                    throw new Exception("Evento não encontrado para o Id: " + id);

                return _mapper.Map<GetEventoResponse>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }

        public async Task<IEnumerable<GetEventoResponse>> GetByTema(string tema, bool includePalestrantes)
        {
            var eventos = await _context.Eventos.Where(a => a.Tema == tema).ToListAsync();
            return _mapper.Map<List<GetEventoResponse>>(eventos);
        }
    }
}