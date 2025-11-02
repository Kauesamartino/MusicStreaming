namespace MusicStreaming.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string AlbumId { get; set; } = string.Empty;
        public int DuracaoSegundos { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int ArtistaId { get; set; }

        public Artista? Artista { get; set; }
    }
}