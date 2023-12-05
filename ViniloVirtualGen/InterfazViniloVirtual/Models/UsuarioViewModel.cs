using System.ComponentModel.DataAnnotations;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;

namespace InterfazViniloVirtual.Models
{
    public class UsuarioViewModel
    {
        [Display(Prompt = "Escribe tu email", Description ="Email del usuario", Name = "Email")]
        [RegularExpression("[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{2,5}", ErrorMessage ="Por favor introduce un formato de email válido")]
        [Required(ErrorMessage = "Debe indicar el email del usuario")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [RegularExpression("(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\[\\]{}\\-_+=|:;'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}", ErrorMessage ="La contraseña debe tener una letra minúscula, una letra mayúscula, un número, un carácter especial y mínimo 8 dígitos")]
        public string Pass { get; set; }

        [Display(Prompt = "Escribe el nombre del usuario", Description = "Nombre del usuario", Name = "Nombre")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "El nombre debe tener al menos 3 letras")]
        [Required(ErrorMessage = "Debe indicar el nombre del usuario")]
        public string Nombre { get; set; }

        [Display(Prompt = "Escribe tu fecha de nacimiento", Description = "Fecha de nacimiento del usuario", Name = "FechaNacimiento")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Debe indicar la fecha de nacieminto del usuario")]
        public Nullable<DateTime> FechaNacimiento { get; set; }

        [Display(Prompt = "Escribe el género del usuario", Description = "Género del usuario", Name = "Genero")]
        [Required(ErrorMessage = "Debe indicar el género del usuario")]
        public GeneroUsuarioEnum Genero { get; set; }

        [Display(Prompt = "Escribe el género del usuario", Description = "Género del usuario", Name = "Estado")]
        public EstadoUsuarioEnum Estado { get; set; }

        [Display(Prompt = "Escribe el género del usuario", Description = "Género del usuario", Name = "Apellido")]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "El apellido debe tener al menos 3 letras")]
        [Required(ErrorMessage = "Debe indicar el apellido del usuario")]
        public string Apellido { get; set; }

        [Display(Prompt = "Selecciona una imagen para el usuario", Description = "Imagen del Usuario", Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Debe indicar la imagen del usuario")]
        public string Imagen { get; set; }


        
    }

    public class loginUsuarioViewModel
    {

        [Display(Prompt = "Introduce tu email", Description = "Email del usuario", Name = "Email")]
        [RegularExpression("[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{2,5}", ErrorMessage = "Por favor introduce un formato de email válido")]
        [Required(ErrorMessage = "Debes introducir tu email")]
        public string Email { get; set; }

        [Display(Prompt = "Introduce tu password", Description = "Password del usuario", Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debes introducir tu password")]       
        public string Pass { get; set; }
    }

    public class registroUsuarioViewModel
    {

        [Display(Prompt = "Introduce tu email", Description = "Email del usuario", Name = "Email")]
        [RegularExpression("[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{2,5}", ErrorMessage = "Por favor introduce un formato de email válido")]
        [Required(ErrorMessage = "Debes introducir el email del usuario")]
        public string Email { get; set; }

        [Display(Prompt = "Introduce tu password", Description = "Password del usuario", Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression("(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\[\\]{}\\-_+=|:;'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}", ErrorMessage = "La contraseña debe tener una letra minúscula, una letra mayúscula, un número, un carácter especial y mínimo 8 dígitos")]
        public string Pass { get; set; }
    }
}