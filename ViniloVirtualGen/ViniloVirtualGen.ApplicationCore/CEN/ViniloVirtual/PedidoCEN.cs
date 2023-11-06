

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public int New_ (Nullable<DateTime> p_fecha, string p_direccion, double p_total, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum p_metodoPago, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum p_estado, string p_usuario)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

        pedidoEN.Direccion = p_direccion;

        pedidoEN.Total = p_total;

        pedidoEN.MetodoPago = p_metodoPago;

        pedidoEN.Estado = p_estado;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                pedidoEN.Usuario = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }



        oid = _IPedidoRepository.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, Nullable<DateTime> p_fecha, string p_direccion, double p_total, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum p_metodoPago, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum p_estado)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Direccion = p_direccion;
        pedidoEN.Total = p_total;
        pedidoEN.MetodoPago = p_metodoPago;
        pedidoEN.Estado = p_estado;
        //Call to PedidoRepository

        _IPedidoRepository.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoRepository.Destroy (id);
}

public PedidoEN GetID (int id
                       )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.GetID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.GetAll (first, size);
        return list;
}
}
}
