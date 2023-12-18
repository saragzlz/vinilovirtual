
using System;
using System.Text;

using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;



/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Usuario_addArtistasFav) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
        public partial class UsuarioCP : GenericBasicCP
        {
                public void AddArtistasFav(int p_oid, string user)
                {
                        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual_Usuario_addArtistasFav) ENABLED START*/
                        UsuarioCEN usuarioCEN = null;
                        ArtistaCEN artCEN = null;


                        try
                        {
                                CPSession.SessionInitializeTransaction();
                                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                                artCEN = new ArtistaCEN(CPSession.UnitRepo.ArtistaRepository);

                                ArtistaEN x = artCEN.GetID(p_oid);

                                UsuarioEN usuarioEN = usuarioCEN.GetID(user);

                                if (usuarioEN.Album.Count > 0)
                                {
                                        usuarioEN.Artista_favoritos.Add(x);
                                }
                                else
                                {
                                        usuarioEN.Artista_favoritos = new List<ArtistaEN>() { x };
                                }


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


                        /*PROTECTED REGION END*/
                }
        }
}
