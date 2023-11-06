
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
 *	Atributo comentario
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario;



/**
 *	Atributo lineaPedido
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN lineaPedido;



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



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public AlbumEN()
{
        comentario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN>();
        usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
}



public AlbumEN(int id, string nombre, string descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum genero, string imagen, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN lineaPedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario
               )
{
        this.init (Id, nombre, descripcion, genero, imagen, artista, comentario, lineaPedido, usuario);
}


public AlbumEN(AlbumEN album)
{
        this.init (album.Id, album.Nombre, album.Descripcion, album.Genero, album.Imagen, album.Artista, album.Comentario, album.LineaPedido, album.Usuario);
}

private void init (int id
                   , string nombre, string descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum genero, string imagen, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artista, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN lineaPedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> usuario)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Genero = genero;

        this.Imagen = imagen;

        this.Artista = artista;

        this.Comentario = comentario;

        this.LineaPedido = lineaPedido;

        this.Usuario = usuario;
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
