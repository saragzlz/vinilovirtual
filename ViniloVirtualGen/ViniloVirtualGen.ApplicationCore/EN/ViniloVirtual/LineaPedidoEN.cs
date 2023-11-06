
using System;
// Definición clase LineaPedidoEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class LineaPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo pedido
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN pedido;



/**
 *	Atributo album
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN Album {
        get { return album; } set { album = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, double precio, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN pedido, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album
                     )
{
        this.init (Id, precio, pedido, album);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (lineaPedido.Id, lineaPedido.Precio, lineaPedido.Pedido, lineaPedido.Album);
}

private void init (int id
                   , double precio, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN pedido, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN album)
{
        this.Id = id;


        this.Precio = precio;

        this.Pedido = pedido;

        this.Album = album;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
