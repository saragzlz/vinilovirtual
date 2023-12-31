

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
        /*
         *      Definition of the class AlbumCEN
         *
         */
        public partial class AlbumCEN
        {
                private IAlbumRepository _IAlbumRepository;

                public AlbumCEN(IAlbumRepository _IAlbumRepository)
                {
                        this._IAlbumRepository = _IAlbumRepository;
                }

                public IAlbumRepository get_IAlbumRepository()
                {
                        return this._IAlbumRepository;
                }

                public int New_(string p_nombre, string p_descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum p_genero, string p_imagen, int p_artista, double p_precio, int p_numLikes)
                {
                        AlbumEN albumEN = null;
                        int oid;

                        //Initialized AlbumEN
                        albumEN = new AlbumEN();
                        albumEN.Nombre = p_nombre;

                        albumEN.Descripcion = p_descripcion;

                        albumEN.Genero = p_genero;

                        albumEN.Imagen = p_imagen;


                        if (p_artista != -1)
                        {
                                // El argumento p_artista -> Property artista es oid = false
                                // Lista de oids id
                                albumEN.Artista = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN();
                                albumEN.Artista.Id = p_artista;
                        }

                        albumEN.Precio = p_precio;

                        albumEN.NumLikes = p_numLikes;



                        oid = _IAlbumRepository.New_(albumEN);
                        return oid;
                }

                public void Modify(int p_Album_OID, string p_nombre, string p_descripcion, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum p_genero, string p_imagen, double p_precio, int p_numLikes)
                {
                        AlbumEN albumEN = null;

                        //Initialized AlbumEN
                        albumEN = new AlbumEN();
                        albumEN.Id = p_Album_OID;
                        albumEN.Nombre = p_nombre;
                        albumEN.Descripcion = p_descripcion;
                        albumEN.Genero = p_genero;
                        albumEN.Imagen = p_imagen;
                        albumEN.Precio = p_precio;
                        albumEN.NumLikes = p_numLikes;
                        //Call to AlbumRepository

                        _IAlbumRepository.Modify(albumEN);
                }

                public void Destroy(int id
                                     )
                {
                        _IAlbumRepository.Destroy(id);
                }

                public AlbumEN GetID(int id
                                      )
                {
                        AlbumEN albumEN = null;

                        albumEN = _IAlbumRepository.GetID(id);
                        return albumEN;
                }

                public System.Collections.Generic.IList<AlbumEN> GetAll(int first, int size)
                {
                        System.Collections.Generic.IList<AlbumEN> list = null;

                        list = _IAlbumRepository.GetAll(first, size);
                        return list;
                }
                public void AnyadirAlbum(int p_Album_OID, int p_artista_OID)
                {
                        //Call to AlbumRepository

                        _IAlbumRepository.AnyadirAlbum(p_Album_OID, p_artista_OID);
                }
                public void EliminarAlbum(int p_Album_OID, int p_artista_OID)
                {
                        //Call to AlbumRepository

                        _IAlbumRepository.EliminarAlbum(p_Album_OID, p_artista_OID);
                }
                public void AnyadirFavorito(int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
                {
                        //Call to AlbumRepository

                        _IAlbumRepository.AnyadirFavorito(p_Album_OID, p_usuario_OIDs);
                }
                public void AnyadirCompra(int p_Album_OID, string p_usuario_OID)
                {
                        //Call to AlbumRepository

                        _IAlbumRepository.AnyadirCompra(p_Album_OID, p_usuario_OID);
                }
                public void EliminarFavorito(int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
                {
                        //Call to AlbumRepository

                        _IAlbumRepository.EliminarFavorito(p_Album_OID, p_usuario_OIDs);
                }


                public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesArtista(int p_id)
                {
                        return _IAlbumRepository.GetAlbumesArtista(p_id);
                }
                public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesFavsUsu(string p_email)
                {
                        return _IAlbumRepository.GetAlbumesFavsUsu(p_email);
                }
                public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumsDelGenero(ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum? p_genero)
                {
                        return _IAlbumRepository.GetAlbumsDelGenero(p_genero);
                }

                public void EliminarListaAlbumesCompra(int p_Album_OID)
                {
                       _IAlbumRepository.EliminarListaAlbumesCompra(p_Album_OID);
                }
        }
}
