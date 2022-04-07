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
using ProEventos.Infra.Context;

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

        public async Task<EventoResponse> Create(EventoRequest request)
        {
            try
            {
                var entity = _mapper.Map<Evento>(request);

                _context.Eventos.Add(entity);

                var result = await _context.SaveChangesAsync();
                if (result == 0) throw new Exception("Erro ao inserir Evento");

                return _mapper.Map<EventoResponse>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoResponse> Update(EventoRequest request)
        {
            try
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(a => a.Id == request.Id);
                if (evento == null) throw new Exception("Evento não encontrado para o Id: " + request.Id);

                evento.Local = request.Local;
                evento.DataEvento = request.DataEvento;
                evento.Tema = request.Tema;
                evento.QuantidadePessoas = request.QuantidadePessoas;
                evento.UrlImagem = request.UrlImagem;
                evento.Telefone = request.Telefone;

                var lotes = _mapper.Map<List<Lote>>(request.Lotes);
                var redesSociais = _mapper.Map<List<RedeSocial>>(request.RedesSociais);

                evento.Lotes = lotes;
                evento.RedesSociais = redesSociais;

                var result = await _context.SaveChangesAsync();
                if (result == 0) throw new Exception("Erro ao atualizar Evento");

                request.Id = evento.Id;

                return _mapper.Map<EventoResponse>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoResponse>> GetAll(bool includePalestrante = false)
        {
            try
            {
                IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

                if (includePalestrante)
                {
                    query = query
                        .Include(a => a.PalestrantesEventos)
                        .ThenInclude(pa => pa.Palestrante);
                }

                query = query.OrderBy(a => a.Id);

                var eventos = await query.ToListAsync();

                return _mapper.Map<List<EventoResponse>>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoResponse> GetById(int id, bool includePalestrante = false)
        {
            try
            {
                IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

                if (includePalestrante)
                {
                    query = query
                        .Include(a => a.PalestrantesEventos)
                        .ThenInclude(pa => pa.Palestrante);
                }

                query = query
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == id);

                var evento = await query.FirstOrDefaultAsync();

                if (evento == null)
                    throw new Exception("Evento não encontrado para o Id: " + id);

                return _mapper.Map<EventoResponse>(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoResponse>> GetByTema(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(a => a.PalestrantesEventos)
                    .ThenInclude(pa => pa.Palestrante);
            }

            query = query
                .OrderBy(a => a.Id)
                .Where(a => a.Tema.ToLower().Contains(tema.ToLower()));

            var eventos = await query.ToListAsync();

            return _mapper.Map<List<EventoResponse>>(eventos);
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var evento = await GetAsNoTracking(id);
                if (evento == null) throw new Exception("Evento não encontrado para o Id: " + id);

                _context.Eventos.Remove(evento);

                var result = await _context.SaveChangesAsync();
                if (result == 0) throw new Exception("Erro ao deletar Evento");

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<Evento> GetAsNoTracking(int id)
        {
            IQueryable<Evento> query = _context.Eventos
                    .Include(a => a.Lotes)
                    .Include(a => a.RedesSociais);

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}