
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarApellido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class UsuarioCEN
{
public void ModificarApellido (string p_email, string p_nuevoApellido)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarApellido) ENABLED START*/

        //Nos guardamos la info del usuario que nos pasan por paramentro en la variable "en"
        UsuarioEN en = _IUsuarioRepository.GetID (p_email);

        en.Apellido = p_nuevoApellido;

        //Actualizada la informacion de "en" con el nuevo apellido, modificamos el usuario de forma final
        _IUsuarioRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
