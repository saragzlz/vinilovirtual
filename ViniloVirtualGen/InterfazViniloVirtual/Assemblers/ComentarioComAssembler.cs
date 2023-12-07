using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;


namespace InterfazViniloVirtual.Assemblers
{
    public class ComentarioComAssembler
    {
        public ComentarioComViewModel ConvertirENToViewModel(ComentarioComEN comentEn)
        {
            ComentarioComViewModel comentViewModel = new ComentarioComViewModel();
            comentViewModel.Texto= comentEn.Texto;
            comentViewModel.NombreUsuario = comentEn.Usuario.Nombre;
            comentViewModel.UsuarioId = comentEn.Usuario.Email;
            comentViewModel.ComunidadId = comentEn.Comunidad.Id;
            return comentViewModel;
        }

        public IList<ComentarioComViewModel> ConvertirListENToViewModel(System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> ens)
        {

            IList<ComentarioComViewModel> comments = new List<ComentarioComViewModel>();
            foreach (ComentarioComEN en in ens)
            {
                comments.Add(ConvertirENToViewModel(en));
            }

            return comments;

        }
    }
}