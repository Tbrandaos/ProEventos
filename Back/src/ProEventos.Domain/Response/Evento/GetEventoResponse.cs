using System.Collections.Generic;
using ProEventos.Domain.Response.Lote;
using ProEventos.Domain.Response.RedeSocial;
using ProEventos.Domain.Response.PalestranteEvento;

namespace ProEventos.Domain.Response.Evento
{
    public class GetEventoResponse
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string Lote { get; set; }
        public string UrlImagem { get; set; }
        public IList<GetLoteResponse> Lotes { get; set; }
        public IList<GetRedeSocialResponse> RedesSociais { get; set; }
        public IList<GetPalestranteEventoResponse> PalestrantesEventos { get; set; }
    }
}