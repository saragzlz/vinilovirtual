using System.ComponentModel.DataAnnotations;

namespace InterfazViniloVirtual.Models{
        
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombra a la Comunidad", Description ="Nombre de la Comunidad", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el nombre de la comunidad")]
        [StringLength(maximumLength:50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Selecciona una imagen para la Comunidad", Description = "Imagen de la Comunidad", Name = "Comunidad")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Debe colocar una imagen a la comunidad")]
        public string imagen { get; set; }
}