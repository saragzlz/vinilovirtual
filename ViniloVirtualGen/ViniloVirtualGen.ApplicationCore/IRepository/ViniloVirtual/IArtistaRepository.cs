
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


ArtistaEN GetID (int id
                 );


System.Collections.Generic.IList<ArtistaEN> GetAll (int first, int size);


void AnyadirFavorito (int p_Artista_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void EliminarFavorito (int p_Artista_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);



System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> GetArtistasFavsUsu (string p_email);
}
}
