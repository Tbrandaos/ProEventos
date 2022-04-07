using System.Collections.Generic;
using ProEventos.Domain.Response.Lote;
using ProEventos.Domain.Response.RedeSocial;
using ProEventos.Domain.Response.PalestranteEvento;

namespace ProEventos.Domain.Response.Evento
{
    public class EventoResponse
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string Lote { get; set; }
        public string UrlImagem { get; set; }
        public IList<LoteResponse> Lotes { get; set; }
        public IList<RedeSocialResponse> RedesSociais { get; set; }
        public IList<PalestranteEventoResponse> PalestrantesEventos { get; set; }
    }
}