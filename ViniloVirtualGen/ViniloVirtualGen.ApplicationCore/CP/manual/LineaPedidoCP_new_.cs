
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_LineaPedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
public partial class LineaPedidoCP : GenericBasicCP
{
public ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN New_ (double p_precio, int p_pedido, int p_album)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_LineaPedido_new_) ENABLED START*/

        LineaPedidoCEN lineaPedidoCEN = null;

        ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                lineaPedidoCEN = new  LineaPedidoCEN (CPSession.UnitRepo.LineaPedidoRepository);

                PedidoCEN pedidoCEN = new PedidoCEN (CPSession.UnitRepo.PedidoRepository);

                AlbumCEN albumCEN = new AlbumCEN (CPSession.UnitRepo.AlbumRepository);


                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();
                lineaPedidoEN.Precio = p_precio;


                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }


                if (p_album != -1) {
                        lineaPedidoEN.Album = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN ();
                        lineaPedidoEN.Album.Id = p_album;
                }

                PedidoEN pedidoEn = pedidoCEN.GetID (p_pedido);
                AlbumEN albumEn = albumCEN.GetID (p_album);

                pedidoEn.Total += lineaPedidoEN.Precio;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoEn);


                oid = lineaPedidoCEN.get_ILineaPedidoRepository ().New_ (lineaPedidoEN);

                result = lineaPedidoCEN.get_ILineaPedidoRepository ().ReadOIDDefault (oid);



                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
