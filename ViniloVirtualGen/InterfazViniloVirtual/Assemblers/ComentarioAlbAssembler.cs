using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;


namespace InterfazViniloVirtual.Assemblers
{
    public class ComentarioAlbAssembler
    {
        public ComentarioAlbViewModel ConvertirENToViewModel(ComentarioAlbEN comentEn)
        {
            ComentarioAlbViewModel comentViewModel = new ComentarioAlbViewModel();
            comentViewModel.Texto= comentEn.Texto;
            comentViewModel.Id = comentEn.Id;
            comentViewModel.NombreUsuario = comentEn.Usuario.Nombre;
            comentViewModel.UsuarioId = comentEn.Usuario.Email;
            comentViewModel.AlbumId = comentEn.Album.Id;
            comentViewModel.Fecha = comentEn.Fecha;
            return comentViewModel;
        }

        public IList<ComentarioAlbViewModel> ConvertirListENToViewModel(System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> ens)
        {

            IList<ComentarioAlbViewModel> comments = new List<ComentarioAlbViewModel>();
            foreach (ComentarioAlbEN en in ens)
            {
                comments.Add(ConvertirENToViewModel(en));
            }

            return comments;

        }
    }
}