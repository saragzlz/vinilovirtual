
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Usuario_addAlbumFav) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
        public partial class UsuarioCP : GenericBasicCP
        {
                public void AddAlbumFav(int p_oid, string user)
                {
                        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Usuario_addAlbumFav) ENABLED START*/

                        UsuarioCEN usuarioCEN = null;
                        AlbumCEN albumCEN = null;


                        try
                        {
                                CPSession.SessionInitializeTransaction();
                                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                                albumCEN = new AlbumCEN(CPSession.UnitRepo.AlbumRepository);

                                AlbumEN x = albumCEN.GetID(p_oid);

                                UsuarioEN usuarioEN = usuarioCEN.GetID(user);

                                if (usuarioEN.Album_favoritos.Count > 0)
                                {
                                        usuarioEN.Album_favoritos.Add(x);
                                }
                                else
                                {
                                        usuarioEN.Album_favoritos = new List<AlbumEN>() { x };
                                }


                                CPSession.Commit();
                        }
                        catch (Exception ex)
                        {
                                CPSession.RollBack();
                                throw ex;
                        }
                        finally
                        {
                                CPSession.SessionClose();
                        }


                        /*PROTECTED REGION END*/
                }
        }
}
