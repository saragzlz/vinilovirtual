

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
