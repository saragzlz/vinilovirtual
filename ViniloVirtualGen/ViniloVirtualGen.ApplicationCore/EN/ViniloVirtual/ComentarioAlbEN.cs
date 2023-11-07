
using System;
// Definición clase ComentarioAlbEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class ComentarioAlbEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario;



/**
 *	Atributo album
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN Album {
        get { return album; } set { album = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ComentarioAlbEN()
{
}



public ComentarioAlbEN(int id, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, string texto, Nullable<DateTime> fecha
                       )
{
        this.init (Id, usuario, album, texto, fecha);
}


public ComentarioAlbEN(ComentarioAlbEN comentarioAlb)
{
        this.init (comentarioAlb.Id, comentarioAlb.Usuario, comentarioAlb.Album, comentarioAlb.Texto, comentarioAlb.Fecha);
}

private void init (int id
                   , ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, string texto, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Album = album;

        this.Texto = texto;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioAlbEN t = obj as ComentarioAlbEN;
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
