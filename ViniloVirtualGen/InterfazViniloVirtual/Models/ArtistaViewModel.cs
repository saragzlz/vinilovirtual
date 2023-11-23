
using System.ComponentModel.DataAnnotations;

namespace InterfazViniloVirtual.Models
{
    public class ArtistaViewModel
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombra al Artista", Description ="Nombre del Artista", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el nombre del artista")]
        [StringLength(maximumLength:50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Describe el Artista", Description = "Descripcion del Artista", Name = "Descripcion")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripcion no puede tener mas de 50 caracteres")]
        public string descripcion { get; set; }

        [Display(Prompt = "Selecciona una imagen para el Artista", Description = "Imagen del Artista", Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Debe indicar la imagen del artista")]
        public string imagen { get; set; }


    }
}
