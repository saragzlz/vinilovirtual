using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;


namespace InterfazViniloVirtual.Assemblers
{
    public class AlbumAssembler
    {
        public AlbumViewModel ConvertirENToViewModel (AlbumEN en)
        {
            AlbumViewModel album = new AlbumViewModel();
            album.Id = en.Id;
            album.Titulo = en.Nombre;
            album.Descripcion = en.Descripcion;
            album.Portada = en.Imagen;
            album.Precio = en.Precio;
            album.Genero = en.Genero;
            album.Likes = en.NumLikes;
            album.Artista = en.Artista;

            return album;
        }

        public IList<AlbumViewModel> ConvertirListENToViewModel(IList<AlbumEN> ens)
        {

            IList<AlbumViewModel> albumes = new List<AlbumViewModel>();
            foreach (AlbumEN en in ens)
            {
                albumes.Add(ConvertirENToViewModel(en));
            }

            return albumes;

        }
    }
}
