using System.ComponentModel.DataAnnotations;

namespace ArtistasApi.Models
{
    public class Artista
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Genero { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required] 
        public string Nacionalidad { get; set; }

        public int CategoriaArtistaId { get; set; }
        public CategoriaArtista CategoriaArtista { get; set; }
    }
}
