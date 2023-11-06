

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioRepository _IComentarioRepository;

public ComentarioCEN(IComentarioRepository _IComentarioRepository)
{
        this._IComentarioRepository = _IComentarioRepository;
}

public IComentarioRepository get_IComentarioRepository ()
{
        return this._IComentarioRepository;
}

public int New_ (string p_texto, int p_usuario, int p_album, int p_comunidad)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Texto = p_texto;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                comentarioEN.Usuario.Id = p_usuario;
        }


        if (p_album != -1) {
                // El argumento p_album -> Property album es oid = false
                // Lista de oids id
                comentarioEN.Album = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN ();
                comentarioEN.Album.Id = p_album;
        }


        if (p_comunidad != -1) {
                // El argumento p_comunidad -> Property comunidad es oid = false
                // Lista de oids id
                comentarioEN.Comunidad = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN ();
                comentarioEN.Comunidad.Id = p_comunidad;
        }



        oid = _IComentarioRepository.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_texto)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Texto = p_texto;
        //Call to ComentarioRepository

        _IComentarioRepository.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioRepository.Destroy (id);
}

public ComentarioEN GetID (int id
                           )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioRepository.GetID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioRepository.GetAll (first, size);
        return list;
}
}
}
