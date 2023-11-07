
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Album_modificarPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class AlbumCEN
{
public void ModificarPrecio (int p_id, double p_nuevoPrecio)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Album_modificarPrecio) ENABLED START*/

        //Nos guardamos la info del album que nos pasan por paramentro en la variable "en"
        AlbumEN en = _IAlbumRepository.GetID (p_id);

        en.Precio = p_nuevoPrecio;

        //Actualizada la informacion de "en" con el nuevo precio, modificamos el album de forma final
        _IAlbumRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
