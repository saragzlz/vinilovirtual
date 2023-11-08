
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IComentarioComRepository
{
void setSessionCP (GenericSessionCP session);

ComentarioComEN ReadOIDDefault (int id
                                );

void ModifyDefault (ComentarioComEN comentarioCom);

System.Collections.Generic.IList<ComentarioComEN> ReadAllDefault (int first, int size);



int New_ (ComentarioComEN comentarioCom);

void Modify (ComentarioComEN comentarioCom);


void Destroy (int id
              );


ComentarioComEN ReadOID (int id
                         );


System.Collections.Generic.IList<ComentarioComEN> ReadAll (int first, int size);


System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> GetComentariosComunidad (int p_id);
}
}
