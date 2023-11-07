
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
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario;



/**
 *	Atributo comentarioCom
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> comentarioCom;






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



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> ComentarioCom {
        get { return comentarioCom; } set { comentarioCom = value;  }
}





public ComunidadEN()
{
        usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
        comentarioCom = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN>();
}



public ComunidadEN(int id, string nombre, string imagen, int numMiembros, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> comentarioCom
                   )
{
        this.init (Id, nombre, imagen, numMiembros, usuario, comentarioCom);
}


public ComunidadEN(ComunidadEN comunidad)
{
        this.init (comunidad.Id, comunidad.Nombre, comunidad.Imagen, comunidad.NumMiembros, comunidad.Usuario, comunidad.ComentarioCom);
}

private void init (int id
                   , string nombre, string imagen, int numMiembros, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> comentarioCom)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Imagen = imagen;

        this.NumMiembros = numMiembros;

        this.Usuario = usuario;

        this.ComentarioCom = comentarioCom;
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
