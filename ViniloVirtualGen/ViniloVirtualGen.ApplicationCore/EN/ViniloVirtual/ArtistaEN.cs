
using System;
// Definición clase ArtistaEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class ArtistaEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo album
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album;



/**
 *	Atributo favoritoArtista
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> favoritoArtista;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> Album {
        get { return album; } set { album = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> FavoritoArtista {
        get { return favoritoArtista; } set { favoritoArtista = value;  }
}





public ArtistaEN()
{
        album = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN>();
        favoritoArtista = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN>();
}



public ArtistaEN(int id, string nombre, string descripcion, string imagen, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> favoritoArtista
                 )
{
        this.init (Id, nombre, descripcion, imagen, album, favoritoArtista);
}


public ArtistaEN(ArtistaEN artista)
{
        this.init (artista.Id, artista.Nombre, artista.Descripcion, artista.Imagen, artista.Album, artista.FavoritoArtista);
}

private void init (int id
                   , string nombre, string descripcion, string imagen, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> favoritoArtista)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Imagen = imagen;

        this.Album = album;

        this.FavoritoArtista = favoritoArtista;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArtistaEN t = obj as ArtistaEN;
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
