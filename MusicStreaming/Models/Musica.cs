using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStreaming.Models
{
    public class Musica
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Titulo { get; set; }

        [Required]
        public required string Genero { get; set; }

        [Display(Name = "Duração (min)")]
        public double Duracao { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Artista")]
        public int ArtistaId { get; set; }

        [ForeignKey("ArtistaId")]
        public Artista? Artista { get; set; }
    }
}
