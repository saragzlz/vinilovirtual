
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Album_pagarAlbum) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
public partial class AlbumCP : GenericBasicCP
{
public void PagarAlbum (int p_oid, string idUsuario)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Album_pagarAlbum) ENABLED START*/

        AlbumCEN albumCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                albumCEN = new  AlbumCEN (CPSession.UnitRepo.AlbumRepository);

                AlbumEN eN = albumCEN.GetID(p_oid);

                UsuarioCEN usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);

                UsuarioEN usuarioEN = usuarioCEN.GetID(idUsuario);

                usuarioEN.Album = new List<AlbumEN>
                {
                    eN
                };

                //Añado album a la coleccion del usuario
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
