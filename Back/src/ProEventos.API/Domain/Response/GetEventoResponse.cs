using System;

namespace ProEventos.API.Domain.Response
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
    }
}