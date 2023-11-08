

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class ComentarioComCEN
 *
 */
public partial class ComentarioComCEN
{
private IComentarioComRepository _IComentarioComRepository;

public ComentarioComCEN(IComentarioComRepository _IComentarioComRepository)
{
        this._IComentarioComRepository = _IComentarioComRepository;
}

public IComentarioComRepository get_IComentarioComRepository ()
{
        return this._IComentarioComRepository;
}

public int New_ (string p_usuario, int p_comunidad, string p_texto, Nullable<DateTime> p_fecha)
{
        ComentarioComEN comentarioComEN = null;
        int oid;

        //Initialized ComentarioComEN
        comentarioComEN = new ComentarioComEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioComEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                comentarioComEN.Usuario.Email = p_usuario;
        }


        if (p_comunidad != -1) {
                // El argumento p_comunidad -> Property comunidad es oid = false
                // Lista de oids id
                comentarioComEN.Comunidad = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN ();
                comentarioComEN.Comunidad.Id = p_comunidad;
        }

        comentarioComEN.Texto = p_texto;

        comentarioComEN.Fecha = p_fecha;



        oid = _IComentarioComRepository.New_ (comentarioComEN);
        return oid;
}

public void Modify (int p_ComentarioCom_OID, string p_texto, Nullable<DateTime> p_fecha)
{
        ComentarioComEN comentarioComEN = null;

        //Initialized ComentarioComEN
        comentarioComEN = new ComentarioComEN ();
        comentarioComEN.Id = p_ComentarioCom_OID;
        comentarioComEN.Texto = p_texto;
        comentarioComEN.Fecha = p_fecha;
        //Call to ComentarioComRepository

        _IComentarioComRepository.Modify (comentarioComEN);
}

public void Destroy (int id
                     )
{
        _IComentarioComRepository.Destroy (id);
}

public ComentarioComEN ReadOID (int id
                                )
{
        ComentarioComEN comentarioComEN = null;

        comentarioComEN = _IComentarioComRepository.ReadOID (id);
        return comentarioComEN;
}

public System.Collections.Generic.IList<ComentarioComEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioComEN> list = null;

        list = _IComentarioComRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> GetComentariosComunidad (int p_id)
{
        return _IComentarioComRepository.GetComentariosComunidad (p_id);
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> GetCommentsComunidadUsu (string p_email)
{
        return _IComentarioComRepository.GetCommentsComunidadUsu (p_email);
}
}
}
