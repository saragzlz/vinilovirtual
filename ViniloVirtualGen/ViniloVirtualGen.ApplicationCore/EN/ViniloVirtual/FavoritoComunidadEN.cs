
using System;
// Definición clase FavoritoComunidadEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class FavoritoComunidadEN
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






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}





public FavoritoComunidadEN()
{
}



public FavoritoComunidadEN(int id, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad
                           )
{
        this.init (Id, usuario, comunidad);
}


public FavoritoComunidadEN(FavoritoComunidadEN favoritoComunidad)
{
        this.init (favoritoComunidad.Id, favoritoComunidad.Usuario, favoritoComunidad.Comunidad);
}

private void init (int id
                   , ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidad)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Comunidad = comunidad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoComunidadEN t = obj as FavoritoComunidadEN;
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
