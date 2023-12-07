using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;

namespace InterfazViniloVirtual.Models
{
    public class ComentarioComViewModel 
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Escribe tu comentario", Description ="Comentario de la comunidad", Name = "Comentario")]
        [Required(ErrorMessage = "Debe escribir un comentario")]
        [StringLength(maximumLength:50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string Texto { get; set; }

        public Nullable<DateTime> Fecha { get; set; }

        public int ComunidadId { get; set; }

        public string UsuarioId { get; set; }

        public string NombreUsuario { get; set; }

    }
}