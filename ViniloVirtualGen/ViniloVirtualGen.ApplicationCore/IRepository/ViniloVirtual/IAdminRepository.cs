
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IAdminRepository
{
void setSessionCP (GenericSessionCP session);

AdminEN ReadOIDDefault (int id
                        );

void ModifyDefault (AdminEN admin);

System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size);



int New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (int id
              );
}
}
