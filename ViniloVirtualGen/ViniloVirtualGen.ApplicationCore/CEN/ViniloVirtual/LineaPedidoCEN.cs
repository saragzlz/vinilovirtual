

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoRepository _ILineaPedidoRepository;

public LineaPedidoCEN(ILineaPedidoRepository _ILineaPedidoRepository)
{
        this._ILineaPedidoRepository = _ILineaPedidoRepository;
}

public ILineaPedidoRepository get_ILineaPedidoRepository ()
{
        return this._ILineaPedidoRepository;
}

public int New_ (double p_precio, int p_pedido, int p_album)
{
        LineaPedidoEN lineaPedidoEN = null;
        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Precio = p_precio;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                lineaPedidoEN.Pedido = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN ();
                lineaPedidoEN.Pedido.Id = p_pedido;
        }


        if (p_album != -1) {
                // El argumento p_album -> Property album es oid = false
                // Lista de oids id
                lineaPedidoEN.Album = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN ();
                lineaPedidoEN.Album.Id = p_album;
        }



        oid = _ILineaPedidoRepository.New_ (lineaPedidoEN);
        return oid;
}

public void Modify (int p_LineaPedido_OID, double p_precio)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Id = p_LineaPedido_OID;
        lineaPedidoEN.Precio = p_precio;
        //Call to LineaPedidoRepository

        _ILineaPedidoRepository.Modify (lineaPedidoEN);
}

public void Destroy (int id
                     )
{
        _ILineaPedidoRepository.Destroy (id);
}

public LineaPedidoEN GetID (int id
                            )
{
        LineaPedidoEN lineaPedidoEN = null;

        lineaPedidoEN = _ILineaPedidoRepository.GetID (id);
        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoRepository.GetAll (first, size);
        return list;
}
}
}
