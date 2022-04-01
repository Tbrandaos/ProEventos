using System;
using MediatR;

namespace ProEventos.Domain.Request.Evento
{
    public class AddEventoRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QuantidadePessoas { get; set; }
        public string UrlImagem { get; set; }
        public string Telefone { get; set; }
    }
}