using ProEventos.Domain.Request.Lote;
using ProEventos.Domain.Request.RedeSocial;
using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Request.Evento
{
    public class EventoRequest
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string UrlImagem { get; set; }
        public string Telefone { get; set; }
        public List<LoteRequest> Lotes { get; set; }
        public List<RedeSocialRequest> RedesSociais { get; set; }
    }
}