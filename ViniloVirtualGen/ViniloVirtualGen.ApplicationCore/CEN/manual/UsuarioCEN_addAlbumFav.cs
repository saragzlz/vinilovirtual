
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_addAlbumFav) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
        public partial class UsuarioCEN
        {
                public void AddAlbumFav(int p_oid, string user)
                {
                        UsuarioEN usu = new UsuarioEN();
                        AlbumEN album = new AlbumEN();
                        try
                        {
                                usu = _IUsuarioRepository.GetID(user);

                                album = _IAlbumRepository.GetID(p_oid);


                                usu.Album_favoritos.Add(album);


                                _IUsuarioRepository.ModifyDefault(usu);
                        }
                        catch (Exception ex)
                        {

                                usu.Album_favoritos = new List<AlbumEN>() { album };
                                _IUsuarioRepository.ModifyDefault(usu);



                        }
                }
        }
}
