using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain.Response.PalestranteEvento
{
    public class GetPalestranteEventoResponse
    {
        public int EventoId { get; set; }
        public int PalestranteId { get; set; }
    }
}