
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Admin_baneoTemporal) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
public partial class AdminCP : GenericBasicCP
{
public void BaneoTemporal (string p_oid)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Admin_baneoTemporal) ENABLED START*/

        UsuarioCEN adminCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                adminCEN = new  UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);

                UsuarioEN usuarioEN = adminCEN.GetID (p_oid);

                //Baneamos al usaurio;
                usuarioEN.Estado = Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoTemporal;

                adminCEN.get_IUsuarioRepository ().ModifyDefault (usuarioEN);

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
