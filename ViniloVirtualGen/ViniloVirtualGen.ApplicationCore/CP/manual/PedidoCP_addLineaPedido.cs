
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_addLineaPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
        public partial class PedidoCP : GenericBasicCP
        {
                public List<int> AddLineaPedido(int idPedido, int idAlbum)
                {
                        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_addLineaPedido) ENABLED START*/

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

                                int linea = lineaPedidoCEN.New_(albumEN.Precio, pedidoEN.Id, albumEN.Id);

                                LineaPedidoEN lineaPedidoEN = lineaPedidoCEN.GetID(linea);

                                if (pedidoEN.LineaPedido.Count > 0 && !pedidoEN.LineaPedido.Contains(lineaPedidoEN))
                                {
                                        pedidoEN.LineaPedido.Add(lineaPedidoEN);
                                        pedidos = this.GetIdLineaPedido(pedidoEN.LineaPedido);

                                }
                                else
                                {
                                        if (pedidoEN.LineaPedido.Count > 0)
                                        {
                                                pedidoEN.LineaPedido.Add(lineaPedidoEN);
                                        }
                                        else
                                        {
                                                pedidoEN.LineaPedido = new List<LineaPedidoEN>() { lineaPedidoEN };
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

                private double CalcularTotal(IList<LineaPedidoEN> lineaPedidoENs)
                {
                        double result = 0;
                        foreach (LineaPedidoEN x in lineaPedidoENs)
                        {
                                result += x.Album.Precio;

                        }
                        return result;
                }

                private List<int> GetIdLineaPedido(IList<LineaPedidoEN> lineaPedidoENs)
                {
                        List<int> result = new List<int>();

                        foreach (LineaPedidoEN x in lineaPedidoENs)
                        {
                                if (!result.Contains(x.Id))
                                {
                                        result.Add(x.Id);
                                }

                        }
                        return result;
                }
        }
}
