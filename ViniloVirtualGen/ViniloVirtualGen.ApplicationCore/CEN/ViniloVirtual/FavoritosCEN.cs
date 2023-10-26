

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class FavoritosCEN
 *
 */
public partial class FavoritosCEN
{
private IFavoritosRepository _IFavoritosRepository;

public FavoritosCEN(IFavoritosRepository _IFavoritosRepository)
{
        this._IFavoritosRepository = _IFavoritosRepository;
}

public IFavoritosRepository get_IFavoritosRepository ()
{
        return this._IFavoritosRepository;
}

public int New_ ()
{
        FavoritosEN favoritosEN = null;
        int oid;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();


        oid = _IFavoritosRepository.New_ (favoritosEN);
        return oid;
}

public void Modify (int p_Favoritos_OID)
{
        FavoritosEN favoritosEN = null;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();
        favoritosEN.Id = p_Favoritos_OID;
        //Call to FavoritosRepository

        _IFavoritosRepository.Modify (favoritosEN);
}

public void Destroy (int id
                     )
{
        _IFavoritosRepository.Destroy (id);
}

public FavoritosEN GiveId (int id
                           )
{
        FavoritosEN favoritosEN = null;

        favoritosEN = _IFavoritosRepository.GiveId (id);
        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> list = null;

        list = _IFavoritosRepository.GiveAll (first, size);
        return list;
}
}
}
