
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IFavoritoComunidadRepository
{
void setSessionCP (GenericSessionCP session);

FavoritoComunidadEN ReadOIDDefault (int id
                                    );

void ModifyDefault (FavoritoComunidadEN favoritoComunidad);

System.Collections.Generic.IList<FavoritoComunidadEN> ReadAllDefault (int first, int size);



int New_ (FavoritoComunidadEN favoritoComunidad);

void Modify (FavoritoComunidadEN favoritoComunidad);


void Destroy (int id
              );


FavoritoComunidadEN ReadOID (int id
                             );


System.Collections.Generic.IList<FavoritoComunidadEN> ReadAll (int first, int size);
}
}
