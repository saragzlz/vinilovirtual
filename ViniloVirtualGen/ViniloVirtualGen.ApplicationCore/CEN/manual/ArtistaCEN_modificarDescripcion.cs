
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Artista_modificarDescripcion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class ArtistaCEN
{
public void ModificarDescripcion (int p_id, string p_nuevaDesc)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Artista_modificarDescripcion) ENABLED START*/

        //Nos guardamos la info del artista que nos pasan por paramentro en la variable "en"
        ArtistaEN en = _IArtistaRepository.GetID (p_id);

        en.Descripcion = p_nuevaDesc;

        //Actualizada la informacion de "en" con la nueva descripcion, modificamos el artista de forma final
        _IArtistaRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
