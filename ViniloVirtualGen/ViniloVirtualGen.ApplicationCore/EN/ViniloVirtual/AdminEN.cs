
using System;
// Definición clase AdminEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class AdminEN                                                                        : ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(string email,
               string nombre, String pass, Nullable<DateTime> fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum estado, string imagen, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artista_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> comentarioAlb, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> comentarioCom, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album, string apellido, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum tipo
               )
{
        this.init (Email, nombre, pass, fechaNac, genero, estado, imagen, comunidad, pedido, album_favoritos, artista_favoritos, comentarioAlb, comentarioCom, album, apellido, tipo);
}


public AdminEN(AdminEN admin)
{
        this.init (admin.Email, admin.Nombre, admin.Pass, admin.FechaNac, admin.Genero, admin.Estado, admin.Imagen, admin.Comunidad, admin.Pedido, admin.Album_favoritos, admin.Artista_favoritos, admin.ComentarioAlb, admin.ComentarioCom, admin.Album, admin.Apellido, admin.Tipo);
}

private void init (string email
                   , string nombre, String pass, Nullable<DateTime> fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum genero, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum estado, string imagen, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN> comunidad, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> pedido, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> artista_favoritos, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> comentarioAlb, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> comentarioCom, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> album, string apellido, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum tipo)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Pass = pass;

        this.FechaNac = fechaNac;

        this.Genero = genero;

        this.Estado = estado;

        this.Imagen = imagen;

        this.Comunidad = comunidad;

        this.Pedido = pedido;

        this.Album_favoritos = album_favoritos;

        this.Artista_favoritos = artista_favoritos;

        this.ComentarioAlb = comentarioAlb;

        this.ComentarioCom = comentarioCom;

        this.Album = album;

        this.Apellido = apellido;

        this.Tipo = tipo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
