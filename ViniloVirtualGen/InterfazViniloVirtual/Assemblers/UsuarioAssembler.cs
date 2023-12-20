using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;


namespace InterfazViniloVirtual.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertirENToViewModel(UsuarioEN usuEn)
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Apellido = usuEn.Apellido;
            usuarioViewModel.Nombre = usuEn.Nombre;
            usuarioViewModel.Genero = usuEn.Genero;
            usuarioViewModel.Estado = usuEn.Estado;
            usuarioViewModel.Email = usuEn.Email;
            usuarioViewModel.FechaNacimiento = usuEn.FechaNac;
            usuarioViewModel.Imagen = usuEn.Imagen;
            usuarioViewModel.Tipo = usuEn.Tipo == ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.administrador ? "A" : "C";
            usuarioViewModel.album_favoritos = new List<int>();
            usuarioViewModel.artistas_favoritos = new List<int>();

            switch (usuEn.Estado)
            {
                case ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoPermanente:
                    usuarioViewModel.Baneado = "P";
                    break;
                case ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoTemporal:
                    usuarioViewModel.Baneado = "T";
                    break;
                default:
                    usuarioViewModel.Baneado = "N";
                    break;
            }
            foreach (AlbumEN x in usuEn.Album_favoritos)
            {
                usuarioViewModel.album_favoritos.Add(x.Id);
            }

            foreach (ArtistaEN x in usuEn.Artista_favoritos)
            {
                usuarioViewModel.artistas_favoritos.Add(x.Id);
            }
            return usuarioViewModel;
        }

        public IList<UsuarioViewModel> ConvertirListENToViewModel(IList<UsuarioEN> ens)
        {

            IList<UsuarioViewModel> users = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                users.Add(ConvertirENToViewModel(en));
            }

            return users;

        }
    }
}