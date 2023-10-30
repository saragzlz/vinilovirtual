
using System;
// Definición clase FavoritoArtistaEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class FavoritoArtistaEN
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
 *	Atributo artista
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN Artista {
        get { return artista; } set { artista = value;  }
}





public FavoritoArtistaEN()
{
}



public FavoritoArtistaEN(int id, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista
                         )
{
        this.init (Id, usuario, artista);
}


public FavoritoArtistaEN(FavoritoArtistaEN favoritoArtista)
{
        this.init (favoritoArtista.Id, favoritoArtista.Usuario, favoritoArtista.Artista);
}

private void init (int id
                   , ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Artista = artista;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoArtistaEN t = obj as FavoritoArtistaEN;
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
