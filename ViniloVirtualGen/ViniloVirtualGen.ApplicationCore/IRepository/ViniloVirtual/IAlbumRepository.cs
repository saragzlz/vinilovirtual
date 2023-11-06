
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IAlbumRepository
{
void setSessionCP (GenericSessionCP session);

AlbumEN ReadOIDDefault (int id
                        );

void ModifyDefault (AlbumEN album);

System.Collections.Generic.IList<AlbumEN> ReadAllDefault (int first, int size);



int New_ (AlbumEN album);

void Modify (AlbumEN album);


void Destroy (int id
              );


AlbumEN GiveId (int id
                );


System.Collections.Generic.IList<AlbumEN> GiveAll (int first, int size);
}
}
