
using System;
// Definición clase FavoritosEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class FavoritosEN
{
/**
 *	Atributo id
 */
private int id;






public virtual int Id {
        get { return id; } set { id = value;  }
}





public FavoritosEN()
{
}



public FavoritosEN(int id
                   )
{
        this.init (Id);
}


public FavoritosEN(FavoritosEN favoritos)
{
        this.init (favoritos.Id);
}

private void init (int id
                   )
{
        this.Id = id;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritosEN t = obj as FavoritosEN;
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
