using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;

namespace InterfazViniloVirtual.Assemblers
{
    public class ComunidadAssembler
    {

        public ComunidadViewModel ConvertirENToViewModel (ComunidadEN en)
        {
            ComunidadViewModel com = new ComunidadViewModel();
            com.Id = en.Id;
            com.Nombre = en.Nombre;
            com.Imagen = en.Imagen;
            com.NumMiembros = en.NumMiembros;
            return com;

        }

        public IList<ComunidadViewModel> ConvertirListENToViewModel (IList<ComunidadEN> cms)
        {

            IList<ComunidadViewModel> comus = new List<ComunidadViewModel>();
            foreach (ComunidadEN en in cms)
            {
                comus.Add(ConvertirENToViewModel(en));
            }

            return comus;
            
        }

    }
}
