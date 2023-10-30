
using System;
// Definición clase FavoritoAlbumEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class FavoritoAlbumEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo album
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album;



/**
 *	Atributo usuario
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN Album {
        get { return album; } set { album = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public FavoritoAlbumEN()
{
}



public FavoritoAlbumEN(int id, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario
                       )
{
        this.init (Id, album, usuario);
}


public FavoritoAlbumEN(FavoritoAlbumEN favoritoAlbum)
{
        this.init (favoritoAlbum.Id, favoritoAlbum.Album, favoritoAlbum.Usuario);
}

private void init (int id
                   , ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario)
{
        this.Id = id;


        this.Album = album;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoAlbumEN t = obj as FavoritoAlbumEN;
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
