
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_addAlbumBuy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
        public partial class UsuarioCEN
        {
                public void AddAlbumBuy(int p_oid, string user)
                {
                        UsuarioEN usu = new UsuarioEN();
                        AlbumEN album = new AlbumEN();
                        try
                        {
                                usu = _IUsuarioRepository.GetID(user);

                                album = _IAlbumRepository.GetID(p_oid);


                                usu.Album.Add(album);


                                _IUsuarioRepository.ModifyDefault(usu);
                        }
                        catch (Exception ex)
                        {
                                if (ex.Message.Contains("ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH.Album, no session or session was closed"))
                                {
                                        usu.Album = new List<AlbumEN>() { album };
                                        _IUsuarioRepository.ModifyDefault(usu);
                                }
                                else
                                {
                                        throw ex;
                                }

                        }


                }
        }
}
