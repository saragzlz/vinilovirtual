
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IFavoritoArtistaRepository
{
void setSessionCP (GenericSessionCP session);

FavoritoArtistaEN ReadOIDDefault (int id
                                  );

void ModifyDefault (FavoritoArtistaEN favoritoArtista);

System.Collections.Generic.IList<FavoritoArtistaEN> ReadAllDefault (int first, int size);



int New_ (FavoritoArtistaEN favoritoArtista);

void Modify (FavoritoArtistaEN favoritoArtista);


void Destroy (int id
              );


FavoritoArtistaEN ReadOID (int id
                           );


System.Collections.Generic.IList<FavoritoArtistaEN> ReadAll (int first, int size);
}
}
