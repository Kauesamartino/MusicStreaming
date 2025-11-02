using System.Collections.Generic;

namespace MusicStreaming.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;

        public ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}