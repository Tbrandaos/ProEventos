using System;
using System.Collections.Generic;

namespace ProEventos.Infra.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string UrlImagem { get; set; }
        public string Telefone { get; set; }
        public IList<Lote> Lotes { get; set; }
        public IList<RedeSocial> RedesSociais { get; set; }
        public IList<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}