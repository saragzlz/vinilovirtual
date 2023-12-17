using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;

namespace InterfazViniloVirtual.Models
{
    public class FiltroViewModel 
    {

        [StringLength(maximumLength: 100, ErrorMessage = "Paramámetro a buscar no puede tener más de 100 caracteres")]
        public string TextoBuscar { get; set; }

    }
}