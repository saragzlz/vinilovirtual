
using System;
// Definición clase AlbumEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class AlbumEN
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
 *	Atributo genero
 */
private ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum genero;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo artista
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo comentarioAlb
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> comentarioAlb;



/**
 *	Atributo usuario_0
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario_0;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN Artista {
        get { return artista; } set { artista = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> ComentarioAlb {
        get { return comentarioAlb; } set { comentarioAlb = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}





public AlbumEN()
{
        lineaPedido = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN>();
        usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
        comentarioAlb = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN>();
        usuario_0 = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
}



public AlbumEN(int id, string nombre, string descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum genero, string imagen, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario, double precio, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> comentarioAlb, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario_0
               )
{
        this.init (Id, nombre, descripcion, genero, imagen, artista, lineaPedido, usuario, precio, comentarioAlb, usuario_0);
}


public AlbumEN(AlbumEN album)
{
        this.init (album.Id, album.Nombre, album.Descripcion, album.Genero, album.Imagen, album.Artista, album.LineaPedido, album.Usuario, album.Precio, album.ComentarioAlb, album.Usuario_0);
}

private void init (int id
                   , string nombre, string descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum genero, string imagen, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario, double precio, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> comentarioAlb, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario_0)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Genero = genero;

        this.Imagen = imagen;

        this.Artista = artista;

        this.LineaPedido = lineaPedido;

        this.Usuario = usuario;

        this.Precio = precio;

        this.ComentarioAlb = comentarioAlb;

        this.Usuario_0 = usuario_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AlbumEN t = obj as AlbumEN;
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
