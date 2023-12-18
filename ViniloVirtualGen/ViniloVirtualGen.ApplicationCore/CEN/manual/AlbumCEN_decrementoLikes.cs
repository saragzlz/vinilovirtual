
using System;
using System.Text;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


/*PROTECTED REGION ID(usingViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Album_decrementoLikes) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
public partial class AlbumCEN
{
public void DecrementoLikes (int p_oid)
{
        /*PROTECTED REGION ID(ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual_Album_decrementoLikes) ENABLED START*/

        AlbumEN en = _IAlbumRepository.GetID(p_oid);
        
        en.NumLikes--;

        _IAlbumRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
