
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IArtistaRepository
{
void setSessionCP (GenericSessionCP session);

ArtistaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ArtistaEN artista);

System.Collections.Generic.IList<ArtistaEN> ReadAllDefault (int first, int size);



int New_ (ArtistaEN artista);

void Modify (ArtistaEN artista);


void Destroy (int id
              );


ArtistaEN GiveId (int id
                  );


System.Collections.Generic.IList<ArtistaEN> GiveAll (int first, int size);
}
}
