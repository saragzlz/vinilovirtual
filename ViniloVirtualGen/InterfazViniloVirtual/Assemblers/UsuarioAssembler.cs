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

            return usuarioViewModel;
        }

        public IList<UsuarioViewModel> ConvertirListENToViewModel (IList<UsuarioEN> ens)
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