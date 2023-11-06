
using System;
// Definición clase UsuarioEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class UsuarioEN
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
 *	Atributo apillidos
 */
private string apillidos;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo attribute
 */
private string attribute;



/**
 *	Atributo comunidad
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario;



/**
 *	Atributo fechaNac
 */
private string fechaNac;



/**
 *	Atributo genero
 */
private string genero;



/**
 *	Atributo favoritoAlbum
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoAlbumEN> favoritoAlbum;



/**
 *	Atributo favoritoComunidad
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoComunidadEN> favoritoComunidad;



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



public virtual string Apillidos {
        get { return apillidos; } set { apillidos = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Attribute {
        get { return attribute; } set { attribute = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual string FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}



public virtual string Genero {
        get { return genero; } set { genero = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoAlbumEN> FavoritoAlbum {
        get { return favoritoAlbum; } set { favoritoAlbum = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoComunidadEN> FavoritoComunidad {
        get { return favoritoComunidad; } set { favoritoComunidad = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> FavoritoArtista {
        get { return favoritoArtista; } set { favoritoArtista = value;  }
}





public UsuarioEN()
{
        comunidad = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN>();
        comentario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN>();
        favoritoAlbum = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoAlbumEN>();
        favoritoComunidad = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoComunidadEN>();
        favoritoArtista = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN>();
}



public UsuarioEN(int id, string nombre, string apillidos, String pass, string imagen, string attribute, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, string fechaNac, string genero, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoAlbumEN> favoritoAlbum, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoComunidadEN> favoritoComunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> favoritoArtista
                 )
{
        this.init (Id, nombre, apillidos, pass, imagen, attribute, comunidad, comentario, fechaNac, genero, favoritoAlbum, favoritoComunidad, favoritoArtista);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Nombre, usuario.Apillidos, usuario.Pass, usuario.Imagen, usuario.Attribute, usuario.Comunidad, usuario.Comentario, usuario.FechaNac, usuario.Genero, usuario.FavoritoAlbum, usuario.FavoritoComunidad, usuario.FavoritoArtista);
}

private void init (int id
                   , string nombre, string apillidos, String pass, string imagen, string attribute, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, string fechaNac, string genero, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoAlbumEN> favoritoAlbum, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoComunidadEN> favoritoComunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.FavoritoArtistaEN> favoritoArtista)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apillidos = apillidos;

        this.Pass = pass;

        this.Imagen = imagen;

        this.Attribute = attribute;

        this.Comunidad = comunidad;

        this.Comentario = comentario;

        this.FechaNac = fechaNac;

        this.Genero = genero;

        this.FavoritoAlbum = favoritoAlbum;

        this.FavoritoComunidad = favoritoComunidad;

        this.FavoritoArtista = favoritoArtista;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
