
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarImagen) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class UsuarioCEN
{
public void ModificarImagen (string p_email, string p_nuevaImagen)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarImagen) ENABLED START*/

        //Nos guardamos la info del usuario que nos pasan por paramentro en la variable "en"
        UsuarioEN en = _IUsuarioRepository.GetID (p_email);

        en.Imagen = p_nuevaImagen;

        //Actualizada la informacion de "en" con la nueva imagen, modificamos el usuario de forma final
        _IUsuarioRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
