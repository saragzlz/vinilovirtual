
using System;
// Definición clase ComentarioEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo usuario
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario;



/**
 *	Atributo album
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album;



/**
 *	Atributo comunidad
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN Album {
        get { return album; } set { album = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string texto, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad
                    )
{
        this.init (Id, texto, usuario, album, comunidad);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (comentario.Id, comentario.Texto, comentario.Usuario, comentario.Album, comentario.Comunidad);
}

private void init (int id
                   , string texto, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad)
{
        this.Id = id;


        this.Texto = texto;

        this.Usuario = usuario;

        this.Album = album;

        this.Comunidad = comunidad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
