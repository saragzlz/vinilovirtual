
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Comunidad_decrementoSeguidores) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class ComunidadCEN
{
public void DecrementoSeguidores (int p_oid)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Comunidad_decrementoSeguidores) ENABLED START*/

        ComunidadEN en = _IComunidadRepository.GetID (p_oid);

        en.NumMiembros--;

        _IComunidadRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
