
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class UsuarioCEN
{
public void ModificarTipo (string p_email, int p_tipo)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarEstado) ENABLED START*/

        //Nos guardamos la info del usuario que nos pasan por paramentro en la variable "en"
        UsuarioEN en = _IUsuarioRepository.GetID (p_email);

        //Comprobamos que accion hacer
        if (p_tipo == 1) {
                en.Tipo = Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar;
        }
        else if (p_tipo == 2) {
                en.Tipo = Enumerated.ViniloVirtual.TipoUsuarioEnum.administrador;
        }

        //Actualizada la informacion de "en" con el nuevo estado, modificamos el usuario de forma final
        _IUsuarioRepository.ModifyDefault (en);


        /*PROTECTED REGION END*/
}
}
}
