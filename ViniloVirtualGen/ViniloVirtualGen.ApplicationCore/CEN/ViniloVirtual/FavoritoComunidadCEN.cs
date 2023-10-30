

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class FavoritoComunidadCEN
 *
 */
public partial class FavoritoComunidadCEN
{
private IFavoritoComunidadRepository _IFavoritoComunidadRepository;

public FavoritoComunidadCEN(IFavoritoComunidadRepository _IFavoritoComunidadRepository)
{
        this._IFavoritoComunidadRepository = _IFavoritoComunidadRepository;
}

public IFavoritoComunidadRepository get_IFavoritoComunidadRepository ()
{
        return this._IFavoritoComunidadRepository;
}

public int New_ (int p_usuario, int p_comunidad)
{
        FavoritoComunidadEN favoritoComunidadEN = null;
        int oid;

        //Initialized FavoritoComunidadEN
        favoritoComunidadEN = new FavoritoComunidadEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                favoritoComunidadEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                favoritoComunidadEN.Usuario.Id = p_usuario;
        }


        if (p_comunidad != -1) {
                // El argumento p_comunidad -> Property comunidad es oid = false
                // Lista de oids id
                favoritoComunidadEN.Comunidad = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN ();
                favoritoComunidadEN.Comunidad.Id = p_comunidad;
        }



        oid = _IFavoritoComunidadRepository.New_ (favoritoComunidadEN);
        return oid;
}

public void Modify (int p_FavoritoComunidad_OID)
{
        FavoritoComunidadEN favoritoComunidadEN = null;

        //Initialized FavoritoComunidadEN
        favoritoComunidadEN = new FavoritoComunidadEN ();
        favoritoComunidadEN.Id = p_FavoritoComunidad_OID;
        //Call to FavoritoComunidadRepository

        _IFavoritoComunidadRepository.Modify (favoritoComunidadEN);
}

public void Destroy (int id
                     )
{
        _IFavoritoComunidadRepository.Destroy (id);
}

public FavoritoComunidadEN ReadOID (int id
                                    )
{
        FavoritoComunidadEN favoritoComunidadEN = null;

        favoritoComunidadEN = _IFavoritoComunidadRepository.ReadOID (id);
        return favoritoComunidadEN;
}

public System.Collections.Generic.IList<FavoritoComunidadEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoComunidadEN> list = null;

        list = _IFavoritoComunidadRepository.ReadAll (first, size);
        return list;
}
}
}
