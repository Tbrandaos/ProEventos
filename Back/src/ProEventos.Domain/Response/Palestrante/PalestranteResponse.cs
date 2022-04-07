using System.Collections.Generic;
using ProEventos.Domain.Response.PalestranteEvento;
using ProEventos.Domain.Response.RedeSocial;

namespace ProEventos.Domain.Response.Palestrante
{
    public class PalestranteResponse
    {
        public int Id { get; set; } 
       public string Nome { get; set; }
       public string Descricao { get; set; }
       public string ImagemUrl { get; set; }
       public string Telefone { get; set; }
       public string Email { get; set; }
       public IList<RedeSocialResponse> RedesSociais { get; set; }
       public IList<PalestranteEventoResponse> PalestrantesEventos { get; set; }
    }
}