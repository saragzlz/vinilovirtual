
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Pedido_modificarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class PedidoCEN
{
public void ModificarEstado (int p_id, int p_estado)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Pedido_modificarEstado) ENABLED START*/

        //Nos guardamos la info del pedido que nos pasan por paramentro en la variable "en"
        PedidoEN en = _IPedidoRepository.GetID (p_id);

        //Comprobamos que accion hacer
        if (p_estado == 1) {
                en.Estado = Enumerated.ViniloVirtual.EstadoPedidoEnum.pendiente;
        }
        else if (p_estado == 2) {
                en.Estado = Enumerated.ViniloVirtual.EstadoPedidoEnum.aceptado;
        }
        else if (p_estado == 3) {
                en.Estado = Enumerated.ViniloVirtual.EstadoPedidoEnum.rechazado;
        }
        else{
                en.Estado = Enumerated.ViniloVirtual.EstadoPedidoEnum.pendiente;
        }

        //Actualizada la informacion de "en" con el nuevo estado, modificamos el pedido de forma final
        _IPedidoRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
