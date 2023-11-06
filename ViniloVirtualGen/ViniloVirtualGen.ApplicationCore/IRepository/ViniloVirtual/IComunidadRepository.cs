
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IComunidadRepository
{
void setSessionCP (GenericSessionCP session);

ComunidadEN ReadOIDDefault (int id
                            );

void ModifyDefault (ComunidadEN comunidad);

System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size);



int New_ (ComunidadEN comunidad);

void Modify (ComunidadEN comunidad);


void Destroy (int id
              );


ComunidadEN GetID (int id
                   );


System.Collections.Generic.IList<ComunidadEN> GetAll (int first, int size);


void SeguirComunidad (int p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void AbandonarComunidad (int p_Comunidad_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);
}
}
