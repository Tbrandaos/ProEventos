using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Request.Evento;
using ProEventos.Domain.Services;
using MediatR;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEventoService _service;
        public EventosController(IEventoService service, IMediator mediator)
        {
            _mediator = mediator;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEventoRequest request)
        {
            var eventoId = await _mediator.Send(request);
            return Ok(eventoId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var eventos = await _service.GetAll(false);
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _service.GetById(id, false);
            return Ok(evento);
        }
    }
}
