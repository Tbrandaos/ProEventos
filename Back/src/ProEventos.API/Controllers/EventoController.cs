using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Domain.Dtos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        [HttpGet]
        public EventoDto Get()
        {
            var evento = new EventoDto()
            {
                Id = 1,
                Local = "Rio de Janeiro",
                DataEvento = DateTime.Now.AddDays(2),
                Tema = "Angular 11 e .Net 5",
                QuantidadePessoas = 250,
                Lote = "Primeiro Lote",
                UrlImagem = ""
            };
            return evento;
        }
    }
}
