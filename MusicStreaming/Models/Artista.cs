using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Models
{
    public class Artista
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Sobrenome { get; set; } = string.Empty;

        public ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
