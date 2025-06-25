using System.ComponentModel.DataAnnotations;

namespace ArtistasApi.Models
{
    public class CategoriaArtista
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public ICollection<Artista> Artistas { get; set; }
    }

}
