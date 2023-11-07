
using System;
// Definición clase ComentarioComEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class ComentarioComEN
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
 *	Atributo comunidad
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad;



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



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ComentarioComEN()
{
}



public ComentarioComEN(int id, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad, string texto, Nullable<DateTime> fecha
                       )
{
        this.init (Id, usuario, comunidad, texto, fecha);
}


public ComentarioComEN(ComentarioComEN comentarioCom)
{
        this.init (comentarioCom.Id, comentarioCom.Usuario, comentarioCom.Comunidad, comentarioCom.Texto, comentarioCom.Fecha);
}

private void init (int id
                   , ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad, string texto, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Comunidad = comunidad;

        this.Texto = texto;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioComEN t = obj as ComentarioComEN;
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
