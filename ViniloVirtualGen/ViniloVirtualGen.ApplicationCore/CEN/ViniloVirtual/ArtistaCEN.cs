

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class ArtistaCEN
 *
 */
public partial class ArtistaCEN
{
private IArtistaRepository _IArtistaRepository;

public ArtistaCEN(IArtistaRepository _IArtistaRepository)
{
        this._IArtistaRepository = _IArtistaRepository;
}

public IArtistaRepository get_IArtistaRepository ()
{
        return this._IArtistaRepository;
}

public int New_ (string p_nombre, string p_descripcion, string p_imagen)
{
        ArtistaEN artistaEN = null;
        int oid;

        //Initialized ArtistaEN
        artistaEN = new ArtistaEN ();
        artistaEN.Nombre = p_nombre;

        artistaEN.Descripcion = p_descripcion;

        artistaEN.Imagen = p_imagen;



        oid = _IArtistaRepository.New_ (artistaEN);
        return oid;
}

public void Modify (int p_Artista_OID, string p_nombre, string p_descripcion, string p_imagen)
{
        ArtistaEN artistaEN = null;

        //Initialized ArtistaEN
        artistaEN = new ArtistaEN ();
        artistaEN.Id = p_Artista_OID;
        artistaEN.Nombre = p_nombre;
        artistaEN.Descripcion = p_descripcion;
        artistaEN.Imagen = p_imagen;
        //Call to ArtistaRepository

        _IArtistaRepository.Modify (artistaEN);
}

public void Destroy (int id
                     )
{
        _IArtistaRepository.Destroy (id);
}

public ArtistaEN GiveId (int id
                         )
{
        ArtistaEN artistaEN = null;

        artistaEN = _IArtistaRepository.GiveId (id);
        return artistaEN;
}

public System.Collections.Generic.IList<ArtistaEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<ArtistaEN> list = null;

        list = _IArtistaRepository.GiveAll (first, size);
        return list;
}
}
}
