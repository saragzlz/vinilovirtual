

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class ComentarioAlbCEN
 *
 */
public partial class ComentarioAlbCEN
{
private IComentarioAlbRepository _IComentarioAlbRepository;

public ComentarioAlbCEN(IComentarioAlbRepository _IComentarioAlbRepository)
{
        this._IComentarioAlbRepository = _IComentarioAlbRepository;
}

public IComentarioAlbRepository get_IComentarioAlbRepository ()
{
        return this._IComentarioAlbRepository;
}

public int New_ (string p_usuario, int p_album, string p_texto, Nullable<DateTime> p_fecha)
{
        ComentarioAlbEN comentarioAlbEN = null;
        int oid;

        //Initialized ComentarioAlbEN
        comentarioAlbEN = new ComentarioAlbEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioAlbEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                comentarioAlbEN.Usuario.Email = p_usuario;
        }


        if (p_album != -1) {
                // El argumento p_album -> Property album es oid = false
                // Lista de oids id
                comentarioAlbEN.Album = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN ();
                comentarioAlbEN.Album.Id = p_album;
        }

        comentarioAlbEN.Texto = p_texto;

        comentarioAlbEN.Fecha = p_fecha;



        oid = _IComentarioAlbRepository.New_ (comentarioAlbEN);
        return oid;
}

public void Modify (int p_ComentarioAlb_OID, string p_texto, Nullable<DateTime> p_fecha)
{
        ComentarioAlbEN comentarioAlbEN = null;

        //Initialized ComentarioAlbEN
        comentarioAlbEN = new ComentarioAlbEN ();
        comentarioAlbEN.Id = p_ComentarioAlb_OID;
        comentarioAlbEN.Texto = p_texto;
        comentarioAlbEN.Fecha = p_fecha;
        //Call to ComentarioAlbRepository

        _IComentarioAlbRepository.Modify (comentarioAlbEN);
}

public void Destroy (int id
                     )
{
        _IComentarioAlbRepository.Destroy (id);
}

public ComentarioAlbEN ReadID (int id
                               )
{
        ComentarioAlbEN comentarioAlbEN = null;

        comentarioAlbEN = _IComentarioAlbRepository.ReadID (id);
        return comentarioAlbEN;
}

public System.Collections.Generic.IList<ComentarioAlbEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioAlbEN> list = null;

        list = _IComentarioAlbRepository.ReadAll (first, size);
        return list;
}
}
}
