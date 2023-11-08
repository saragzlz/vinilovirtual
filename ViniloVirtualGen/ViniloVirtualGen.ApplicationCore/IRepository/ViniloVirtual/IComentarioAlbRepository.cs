
using System;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public partial interface IComentarioAlbRepository
{
void setSessionCP (GenericSessionCP session);

ComentarioAlbEN ReadOIDDefault (int id
                                );

void ModifyDefault (ComentarioAlbEN comentarioAlb);

System.Collections.Generic.IList<ComentarioAlbEN> ReadAllDefault (int first, int size);



int New_ (ComentarioAlbEN comentarioAlb);

void Modify (ComentarioAlbEN comentarioAlb);


void Destroy (int id
              );


ComentarioAlbEN ReadID (int id
                        );


System.Collections.Generic.IList<ComentarioAlbEN> ReadAll (int first, int size);


System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioAlbEN> GetComentariosAlbum (int p_id);
}
}
