﻿using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
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
            album.Precio = en.Precio.ToString();
            album.Genero = en.Genero;
            album.Likes = en.NumLikes;
            album.Artista = en.Artista;
            album.NombreArtista = en.Artista.Nombre;

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
