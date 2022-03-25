using System.Collections.Generic;

namespace ProEventos.Infra.Entities
{
    public class Palestrante
    {
       public int Id { get; set; } 
       public string Nome { get; set; }
       public string Descricao { get; set; }
       public string ImagemUrl { get; set; }
       public string Telefone { get; set; }
       public string Email { get; set; }
       public IList<RedeSocial> RedesSociais { get; set; }
       public IList<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}