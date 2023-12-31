
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


AlbumEN GetID (int id
               );


System.Collections.Generic.IList<AlbumEN> GetAll (int first, int size);



void AnyadirAlbum (int p_Album_OID, int p_artista_OID);

void EliminarAlbum (int p_Album_OID, int p_artista_OID);

void AnyadirFavorito (int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);

void EliminarFavorito (int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs);


void AnyadirCompra (int p_Album_OID, string p_usuario_OID);

void EliminarListaAlbumesCompra(int p_Album_OID);


System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesArtista (int p_id);


System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesFavsUsu (string p_email);


System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumsDelGenero (ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum ? p_genero);
}
}
