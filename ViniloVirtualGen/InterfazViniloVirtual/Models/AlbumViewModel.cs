using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;

namespace InterfazViniloVirtual.Models
{
    public class AlbumViewModel
    {
        // ID
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        // TITULO DEL ALBUM
        [Display(Prompt = "Introduce el titulo del Album", Description = "Titulo del Album", Name = "Titulo")]
        [Required(ErrorMessage = "Debe indicar el titulo del album.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El titulo del album no puede exceder los 50 caracteres.")]

        public string Titulo { get; set; }

        // DESCRIPCION DEL ALBUM
        [Display(Prompt = "Describe brevemente del Album", Description = "Descripcion del album", Name = "Descripcion")]
        [Required(ErrorMessage = "El album debe tener una breve descripcion.")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripcion del album no puede exceder los 200 caracteres.")]
        public string Descripcion { get; set; }

        // GENERO MUSICAL DEL ALBUM
        [Display(Prompt = "Seleccione el genero musical del Album", Description = "Genero musical del Album", Name = "Genero ")]
        [Required(ErrorMessage = "Debe seleccionar el género musical del album.")]
        public GeneroMusicalEnum Genero { get; set; }

        // PORTADA DEL ALBUM
        [Display(Prompt = "Selecciona una portada para el Album", Description = "Portada del Album", Name = "Portada")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Debe seleccionar una portada para el album")]
        public string Portada { get; set; }

        [Display(Prompt = "Imagen", Description = "Imagen del Artículo", Name = "Imagen")]
        public IFormFile Fichero { get; set; }

        // PRECIO DEL ALBUM
        [Display(Prompt = "Introduce el precio del album", Description = "Precio del album", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del album.")]
        [RegularExpression("^[0-9]+([.])?([0-9]+)?$", ErrorMessage = "El formato de precio incorrecto")]

        public string Precio { get; set; }

        // NUMERO DE LIKES
        [Display(Prompt = "Introduce un numero de likes para el album", Description = "Numero de likes del album", Name = "Likes")]
        [Required(ErrorMessage = "Debe introducir el numero de likes.")]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Debe introducir un numero de likes, siendo el minimo 0.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un valor numerico")]
        public int Likes { get; set; }

        // ARTISTA -----
        // Propiedad para almacenar el artista seleccionado
        [Display(Prompt = "Seleccione un artista para el album", Description = "Artista del Album", Name = "Artista")]
        public ArtistaEN Artista { get; set; }

        [Display(Prompt = "Seleccione un artista para el album", Description = "Artista del Album", Name = "Artista")]
        [Required(ErrorMessage = "Seleccione un artista")]
        public int IdArtista { get; set; }

        // Lista de artistas disponibles
        private static readonly List<ArtistaEN> artistaENs = new List<ArtistaEN>();
        public List<ArtistaEN> ArtistaENs = artistaENs;

        public string NombreArtista { get; set; }

        public bool IsFav { get; set; }
    }
}
