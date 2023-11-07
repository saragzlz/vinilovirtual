
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Artista_modificarImagen) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class ArtistaCEN
{
public void ModificarImagen (int p_id, string p_nuevaImagen)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Artista_modificarImagen) ENABLED START*/

        //Nos guardamos la info del artista que nos pasan por paramentro en la variable "en"
        ArtistaEN en = _IArtistaRepository.GetID (p_id);

        en.Imagen = p_nuevaImagen;

        //Actualizada la informacion de "en" con la nueva descripcion, modificamos el artista de forma final
        _IArtistaRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
