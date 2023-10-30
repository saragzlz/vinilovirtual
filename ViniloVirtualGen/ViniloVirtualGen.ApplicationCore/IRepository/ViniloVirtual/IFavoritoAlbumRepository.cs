
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IFavoritoAlbumRepository
{
void setSessionCP (GenericSessionCP session);

FavoritoAlbumEN ReadOIDDefault (int id
                                );

void ModifyDefault (FavoritoAlbumEN favoritoAlbum);

System.Collections.Generic.IList<FavoritoAlbumEN> ReadAllDefault (int first, int size);



int New_ (FavoritoAlbumEN favoritoAlbum);

void Modify (FavoritoAlbumEN favoritoAlbum);


void Destroy (int id
              );


FavoritoAlbumEN GiveId (int id
                        );


System.Collections.Generic.IList<FavoritoAlbumEN> GiveAll (int first, int size);
}
}
