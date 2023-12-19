
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using System.Linq;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_removeLineaPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/
namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
    public partial class PedidoCP : GenericBasicCP
    {
        public List<int> RemoveLineaPedido(int idPedido, int idAlbum)
        {

            /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_removeLineaPedido) ENABLED START*/

            PedidoCEN pedidoCEN = null;
            LineaPedidoCEN lineaPedidoCEN = null;
            AlbumCEN albumCEN = null;
            List<int> pedidos = new List<int>();



            try
            {
                CPSession.SessionInitializeTransaction();
                pedidoCEN = new PedidoCEN(CPSession.UnitRepo.PedidoRepository);
                lineaPedidoCEN = new LineaPedidoCEN(CPSession.UnitRepo.LineaPedidoRepository);
                albumCEN = new AlbumCEN(CPSession.UnitRepo.AlbumRepository);

                AlbumEN albumEN = albumCEN.GetID(idAlbum);

                PedidoEN pedidoEN = pedidoCEN.GetID(idPedido);

                if (pedidoEN.LineaPedido.Count > 0)
                {
                    IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.LineaPedidoEN> LineaPedidoCopy = pedidoEN.LineaPedido;
                    foreach (LineaPedidoEN x in LineaPedidoCopy)
                    {
                        if (x.Album.Id == idAlbum)
                        {
                            List<LineaPedidoEN> vv =  pedidoEN.LineaPedido.Where(x => x.Album.Id != idAlbum).ToList();
                            pedidoEN.LineaPedido = vv;
                        }
                    }

                    pedidos = this.GetIdLineaPedido(pedidoEN.LineaPedido);

                }

                pedidoEN.Total = this.CalcularTotal(pedidoEN.LineaPedido);

                CPSession.Commit();

            }
            catch (Exception ex)
            {
                CPSession.RollBack();

            }
            finally
            {
                CPSession.SessionClose();

            }

            return pedidos;
            /*PROTECTED REGION END*/
        }
    }
}