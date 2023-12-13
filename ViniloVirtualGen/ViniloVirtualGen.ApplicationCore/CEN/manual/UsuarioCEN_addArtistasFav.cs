
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_addArtistasFav) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
        public partial class UsuarioCEN
        {
                public void AddArtistasFav(int p_oid, string user)
                {
                        UsuarioEN usu = new UsuarioEN();
                        ArtistaEN artista = new ArtistaEN();
                        try
                        {
                                usu = _IUsuarioRepository.GetID(user);

                                artista = _ArtistaRepository.GetID(p_oid);


                                usu.Artista_favoritos.Add(artista);


                                _IUsuarioRepository.ModifyDefault(usu);
                        }
                        catch (Exception ex)
                        {

                                usu.Artista_favoritos = new List<ArtistaEN>() { artista };
                                _IUsuarioRepository.ModifyDefault(usu);



                        }
                }
        }
}
