
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
private ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido;



/**
 *	Atributo albumes_favoritos
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> albumes_favoritos;



/**
 *	Atributo artistas_favoritos
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artistas_favoritos;






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



public virtual ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> Albumes_favoritos {
        get { return albumes_favoritos; } set { albumes_favoritos = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> Artistas_favoritos {
        get { return artistas_favoritos; } set { artistas_favoritos = value;  }
}





public UsuarioEN()
{
        comunidad = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN>();
        comentario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN>();
        pedido = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN>();
        albumes_favoritos = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN>();
        artistas_favoritos = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN>();
}



public UsuarioEN(int id, string nombre, string apillidos, String pass, string imagen, string attribute, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, string fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> albumes_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artistas_favoritos
                 )
{
        this.init (Id, nombre, apillidos, pass, imagen, attribute, comunidad, comentario, fechaNac, genero, pedido, albumes_favoritos, artistas_favoritos);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Nombre, usuario.Apillidos, usuario.Pass, usuario.Imagen, usuario.Attribute, usuario.Comunidad, usuario.Comentario, usuario.FechaNac, usuario.Genero, usuario.Pedido, usuario.Albumes_favoritos, usuario.Artistas_favoritos);
}

private void init (int id
                   , string nombre, string apillidos, String pass, string imagen, string attribute, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, string fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> albumes_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artistas_favoritos)
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

        this.Pedido = pedido;

        this.Albumes_favoritos = albumes_favoritos;

        this.Artistas_favoritos = artistas_favoritos;
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
