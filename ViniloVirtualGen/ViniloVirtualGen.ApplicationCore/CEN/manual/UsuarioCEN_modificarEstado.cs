
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
public void ModificarEstado (string p_email, int p_estado)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Usuario_modificarEstado) ENABLED START*/

        //Nos guardamos la info del usuario que nos pasan por paramentro en la variable "en"
        UsuarioEN en = _IUsuarioRepository.GetID (p_email);

        //Comprobamos que accion hacer
        if (p_estado == 1) {
                en.Estado = Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal;
        }
        else if (p_estado == 2) {
                en.Estado = Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoTemporal;
        }
        else if (p_estado == 3) {
                en.Estado = Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoPermanente;
        }
        else{
                en.Estado = Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal;
        }

        //Actualizada la informacion de "en" con el nuevo estado, modificamos el usuario de forma final
        _IUsuarioRepository.ModifyDefault (en);


        /*PROTECTED REGION END*/
}
}
}
