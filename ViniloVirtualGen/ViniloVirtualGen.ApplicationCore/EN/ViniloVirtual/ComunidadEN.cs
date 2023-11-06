
using System;
// Definición clase ComunidadEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class ComunidadEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo numMiembros
 */
private int numMiembros;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual int NumMiembros {
        get { return numMiembros; } set { numMiembros = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComunidadEN()
{
        comentario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN>();
        usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
}



public ComunidadEN(int id, string nombre, string imagen, int numMiembros, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario
                   )
{
        this.init (Id, nombre, imagen, numMiembros, comentario, usuario);
}


public ComunidadEN(ComunidadEN comunidad)
{
        this.init (comunidad.Id, comunidad.Nombre, comunidad.Imagen, comunidad.NumMiembros, comunidad.Comentario, comunidad.Usuario);
}

private void init (int id
                   , string nombre, string imagen, int numMiembros, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Imagen = imagen;

        this.NumMiembros = numMiembros;

        this.Comentario = comentario;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComunidadEN t = obj as ComunidadEN;
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
