

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class FavoritoArtistaCEN
 *
 */
public partial class FavoritoArtistaCEN
{
private IFavoritoArtistaRepository _IFavoritoArtistaRepository;

public FavoritoArtistaCEN(IFavoritoArtistaRepository _IFavoritoArtistaRepository)
{
        this._IFavoritoArtistaRepository = _IFavoritoArtistaRepository;
}

public IFavoritoArtistaRepository get_IFavoritoArtistaRepository ()
{
        return this._IFavoritoArtistaRepository;
}

public int New_ (int p_usuario, int p_artista)
{
        FavoritoArtistaEN favoritoArtistaEN = null;
        int oid;

        //Initialized FavoritoArtistaEN
        favoritoArtistaEN = new FavoritoArtistaEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                favoritoArtistaEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                favoritoArtistaEN.Usuario.Id = p_usuario;
        }


        if (p_artista != -1) {
                // El argumento p_artista -> Property artista es oid = false
                // Lista de oids id
                favoritoArtistaEN.Artista = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN ();
                favoritoArtistaEN.Artista.Id = p_artista;
        }



        oid = _IFavoritoArtistaRepository.New_ (favoritoArtistaEN);
        return oid;
}

public void Modify (int p_FavoritoArtista_OID)
{
        FavoritoArtistaEN favoritoArtistaEN = null;

        //Initialized FavoritoArtistaEN
        favoritoArtistaEN = new FavoritoArtistaEN ();
        favoritoArtistaEN.Id = p_FavoritoArtista_OID;
        //Call to FavoritoArtistaRepository

        _IFavoritoArtistaRepository.Modify (favoritoArtistaEN);
}

public void Destroy (int id
                     )
{
        _IFavoritoArtistaRepository.Destroy (id);
}

public FavoritoArtistaEN ReadOID (int id
                                  )
{
        FavoritoArtistaEN favoritoArtistaEN = null;

        favoritoArtistaEN = _IFavoritoArtistaRepository.ReadOID (id);
        return favoritoArtistaEN;
}

public System.Collections.Generic.IList<FavoritoArtistaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoArtistaEN> list = null;

        list = _IFavoritoArtistaRepository.ReadAll (first, size);
        return list;
}
}
}
