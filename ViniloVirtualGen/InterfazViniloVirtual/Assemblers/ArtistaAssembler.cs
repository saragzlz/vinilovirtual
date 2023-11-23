using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;

namespace InterfazViniloVirtual.Assemblers
{
    public class ArtistaAssembler
    {

        public ArtistaViewModel ConvertirENToViewModel (ArtistaEN en)
        {
            ArtistaViewModel art = new ArtistaViewModel();
            art.id = en.Id;
            art.nombre = en.Nombre;
            art.descripcion = en.Descripcion;
            art.imagen = en.Imagen;

            return art;

        }

        public IList<ArtistaViewModel> ConvertirListENToViewModel (IList<ArtistaEN> ens)
        {

            IList<ArtistaViewModel> arts = new List<ArtistaViewModel>();
            foreach (ArtistaEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }

            return arts;
            
        }

    }
}
