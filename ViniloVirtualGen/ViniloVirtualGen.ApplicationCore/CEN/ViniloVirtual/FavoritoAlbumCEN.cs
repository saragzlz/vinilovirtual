

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class FavoritoAlbumCEN
 *
 */
public partial class FavoritoAlbumCEN
{
private IFavoritoAlbumRepository _IFavoritoAlbumRepository;

public FavoritoAlbumCEN(IFavoritoAlbumRepository _IFavoritoAlbumRepository)
{
        this._IFavoritoAlbumRepository = _IFavoritoAlbumRepository;
}

public IFavoritoAlbumRepository get_IFavoritoAlbumRepository ()
{
        return this._IFavoritoAlbumRepository;
}

public int New_ (int p_album, int p_usuario)
{
        FavoritoAlbumEN favoritoAlbumEN = null;
        int oid;

        //Initialized FavoritoAlbumEN
        favoritoAlbumEN = new FavoritoAlbumEN ();

        if (p_album != -1) {
                // El argumento p_album -> Property album es oid = false
                // Lista de oids id
                favoritoAlbumEN.Album = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN ();
                favoritoAlbumEN.Album.Id = p_album;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                favoritoAlbumEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                favoritoAlbumEN.Usuario.Id = p_usuario;
        }



        oid = _IFavoritoAlbumRepository.New_ (favoritoAlbumEN);
        return oid;
}

public void Modify (int p_FavoritoAlbum_OID)
{
        FavoritoAlbumEN favoritoAlbumEN = null;

        //Initialized FavoritoAlbumEN
        favoritoAlbumEN = new FavoritoAlbumEN ();
        favoritoAlbumEN.Id = p_FavoritoAlbum_OID;
        //Call to FavoritoAlbumRepository

        _IFavoritoAlbumRepository.Modify (favoritoAlbumEN);
}

public void Destroy (int id
                     )
{
        _IFavoritoAlbumRepository.Destroy (id);
}

public FavoritoAlbumEN GiveId (int id
                               )
{
        FavoritoAlbumEN favoritoAlbumEN = null;

        favoritoAlbumEN = _IFavoritoAlbumRepository.GiveId (id);
        return favoritoAlbumEN;
}

public System.Collections.Generic.IList<FavoritoAlbumEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoAlbumEN> list = null;

        list = _IFavoritoAlbumRepository.GiveAll (first, size);
        return list;
}
}
}
