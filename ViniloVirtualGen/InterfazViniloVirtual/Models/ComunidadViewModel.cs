using System.ComponentModel.DataAnnotations;

namespace InterfazViniloVirtual.Models
{
        public class ComunidadViewModel 
        {
                [ScaffoldColumn(false)]
                public int Id { get; set; }

                [Display(Prompt = "Nombra a la Comunidad", Description ="Nombre de la Comunidad", Name = "Nombre")]
                [Required(ErrorMessage = "Debe indicar el nombre de la comunidad")]
                [StringLength(maximumLength:50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
                public string Nombre { get; set; }

                [Display(Prompt = "Selecciona una imagen para la Comunidad", Description = "Imagen de la Comunidad", Name = "Imagen")]
                [DataType(DataType.ImageUrl)]
                [Required(ErrorMessage = "Debe colocar una imagen a la comunidad")]
                public string Imagen { get; set; }

                [Display(Prompt = "Número de miembros de la comunidad", Description = "Total de miembros de la Comunidad", Name = "NumMiembros")]
                public int NumMiembros { get; set; }
        }
        
}