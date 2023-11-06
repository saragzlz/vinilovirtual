

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class ComunidadCEN
 *
 */
public partial class ComunidadCEN
{
private IComunidadRepository _IComunidadRepository;

public ComunidadCEN(IComunidadRepository _IComunidadRepository)
{
        this._IComunidadRepository = _IComunidadRepository;
}

public IComunidadRepository get_IComunidadRepository ()
{
        return this._IComunidadRepository;
}

public int New_ (string p_nombre, string p_imagen, int p_numMiembros)
{
        ComunidadEN comunidadEN = null;
        int oid;

        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Nombre = p_nombre;

        comunidadEN.Imagen = p_imagen;

        comunidadEN.NumMiembros = p_numMiembros;



        oid = _IComunidadRepository.New_ (comunidadEN);
        return oid;
}

public void Modify (int p_Comunidad_OID, string p_nombre, string p_imagen, int p_numMiembros)
{
        ComunidadEN comunidadEN = null;

        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Id = p_Comunidad_OID;
        comunidadEN.Nombre = p_nombre;
        comunidadEN.Imagen = p_imagen;
        comunidadEN.NumMiembros = p_numMiembros;
        //Call to ComunidadRepository

        _IComunidadRepository.Modify (comunidadEN);
}

public void Destroy (int id
                     )
{
        _IComunidadRepository.Destroy (id);
}

public ComunidadEN GiveId (int id
                           )
{
        ComunidadEN comunidadEN = null;

        comunidadEN = _IComunidadRepository.GiveId (id);
        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> list = null;

        list = _IComunidadRepository.GiveAll (first, size);
        return list;
}
}
}
