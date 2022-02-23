using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Domain.Response;
using ProEventos.API.Domain.Services;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _service;
        public EventosController(IEventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var eventos = await _service.GetAll();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _service.GetById(id);
            return Ok(evento);
        }
    }
}
