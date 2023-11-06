
using System;
// Definición clase PedidoEN
namespace ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo metodoPago
 */
private ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum metodoPago;



/**
 *	Atributo estado
 */
private ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum estado;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido;



/**
 *	Atributo usuario
 */
private ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN>();
}



public PedidoEN(int id, Nullable<DateTime> fecha, string direccion, double total, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum metodoPago, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum estado, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario
                )
{
        this.init (Id, fecha, direccion, total, metodoPago, estado, lineaPedido, usuario);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.Id, pedido.Fecha, pedido.Direccion, pedido.Total, pedido.MetodoPago, pedido.Estado, pedido.LineaPedido, pedido.Usuario);
}

private void init (int id
                   , Nullable<DateTime> fecha, string direccion, double total, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum metodoPago, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum estado, System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> lineaPedido, ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuario)
{
        this.Id = id;


        this.Fecha = fecha;

        this.Direccion = direccion;

        this.Total = total;

        this.MetodoPago = metodoPago;

        this.Estado = estado;

        this.LineaPedido = lineaPedido;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
