
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarPass) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class UsuarioCEN
{
public void ModificarPass (string p_email, String p_nuevaPass)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarPass) ENABLED START*/

        //Nos guardamos la info del usuario que nos pasan por paramentro en la variable "en"
        UsuarioEN en = _IUsuarioRepository.GetID (p_email);

        Console.WriteLine (en.Pass);

        en.Pass = Utils.Util.GetEncondeMD5(p_nuevaPass);

        Console.WriteLine (en.Pass);

        //Actualizada la informacion de "en" con el nuevo nombre, modificamos el usuario de forma final
        _IUsuarioRepository.ModifyDefault (en);



        /*PROTECTED REGION END*/
}
}
}
