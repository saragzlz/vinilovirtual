
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IFavoritosRepository
{
void setSessionCP (GenericSessionCP session);

FavoritosEN ReadOIDDefault (int id
                            );

void ModifyDefault (FavoritosEN favoritos);

System.Collections.Generic.IList<FavoritosEN> ReadAllDefault (int first, int size);



int New_ (FavoritosEN favoritos);

void Modify (FavoritosEN favoritos);


void Destroy (int id
              );


FavoritosEN GiveId (int id
                    );


System.Collections.Generic.IList<FavoritosEN> GiveAll (int first, int size);
}
}
