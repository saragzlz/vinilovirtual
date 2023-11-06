
using System;
// Definición clase AdminEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class AdminEN                                                                        : ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(int id,
               string nombre, string apillidos, String pass, string imagen, string attribute, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioEN> comentario, string fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> albumes_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artistas_favoritos
               )
{
        this.init (Id, nombre, apillidos, pass, imagen, attribute, comunidad, comentario, fechaNac, genero, pedido, albumes_favoritos, artistas_favoritos);
}


public AdminEN(AdminEN admin)
{
        this.init (admin.Id, admin.Nombre, admin.Apillidos, admin.Pass, admin.Imagen, admin.Attribute, admin.Comunidad, admin.Comentario, admin.FechaNac, admin.Genero, admin.Pedido, admin.Albumes_favoritos, admin.Artistas_favoritos);
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
        AdminEN t = obj as AdminEN;
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
