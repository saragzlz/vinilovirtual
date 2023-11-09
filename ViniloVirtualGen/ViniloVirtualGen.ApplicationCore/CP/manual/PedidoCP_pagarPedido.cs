
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_pagarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
public partial class PedidoCP : GenericBasicCP
{
public void PagarPedido (int p_oid, string emailUsuario)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Pedido_pagarPedido) ENABLED START*/

        PedidoCEN pedidoCEN = null;
        UsuarioCEN usuarioCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);
                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                PedidoEN pedidoEN = pedidoCEN.GetID(p_oid);

                UsuarioEN usuarioEN = usuarioCEN.GetID(emailUsuario);

                foreach(LineaPedidoEN x in pedidoEN.LineaPedido){
                        usuarioEN.Album.Add(x.Album);
                }

  
                usuarioCEN.get_IUsuarioRepository().ModifyDefault(usuarioEN);



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


        /*PROTECTED REGION END*/
}
}
}
