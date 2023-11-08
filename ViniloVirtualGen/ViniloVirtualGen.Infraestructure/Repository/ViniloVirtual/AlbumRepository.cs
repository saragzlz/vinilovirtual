
using System;
using System.Text;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.Exceptions;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.EN.ViniloVirtual;


/*
 * Clase Album:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class AlbumRepository : BasicRepository, IAlbumRepository
{
public AlbumRepository() : base ()
{
}


public AlbumRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AlbumEN ReadOIDDefault (int id
                               )
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}

public System.Collections.Generic.IList<AlbumEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AlbumEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AlbumNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AlbumEN>();
                        else
                                result = session.CreateCriteria (typeof(AlbumNH)).List<AlbumEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumNH albumNH = (AlbumNH)session.Load (typeof(AlbumNH), album.Id);

                albumNH.Nombre = album.Nombre;


                albumNH.Descripcion = album.Descripcion;


                albumNH.Genero = album.Genero;


                albumNH.Imagen = album.Imagen;





                albumNH.Precio = album.Precio;



                session.Update (albumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AlbumEN album)
{
        AlbumNH albumNH = new AlbumNH (album);

        try
        {
                SessionInitializeTransaction ();
                if (album.Artista != null) {
                        // Argumento OID y no colección.
                        albumNH
                        .Artista = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN), album.Artista.Id);

                        albumNH.Artista.Album
                        .Add (albumNH);
                }

                session.Save (albumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return albumNH.Id;
}

public void Modify (AlbumEN album)
{
        try
        {
                SessionInitializeTransaction ();
                AlbumNH albumNH = (AlbumNH)session.Load (typeof(AlbumNH), album.Id);

                albumNH.Nombre = album.Nombre;


                albumNH.Descripcion = album.Descripcion;


                albumNH.Genero = album.Genero;


                albumNH.Imagen = album.Imagen;


                albumNH.Precio = album.Precio;

                session.Update (albumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AlbumNH albumNH = (AlbumNH)session.Load (typeof(AlbumNH), id);
                session.Delete (albumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetID
//Con e: AlbumEN
public AlbumEN GetID (int id
                      )
{
        AlbumEN albumEN = null;

        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Get (typeof(AlbumNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return albumEN;
}

public System.Collections.Generic.IList<AlbumEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<AlbumEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AlbumNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AlbumEN>();
                else
                        result = session.CreateCriteria (typeof(AlbumNH)).List<AlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirAlbum (int p_Album_OID, int p_artista_OID)
{
        ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN albumEN = null;
        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Load (typeof(AlbumNH), p_Album_OID);
                albumEN.Artista = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.ArtistaNH), p_artista_OID);

                albumEN.Artista.Album.Add (albumEN);



                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarAlbum (int p_Album_OID, int p_artista_OID)
{
        try
        {
                SessionInitializeTransaction ();
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN albumEN = null;
                albumEN = (AlbumEN)session.Load (typeof(AlbumNH), p_Album_OID);

                if (albumEN.Artista.Id == p_artista_OID) {
                        albumEN.Artista = null;
                }
                else
                        throw new ModelException ("The identifier " + p_artista_OID + " in p_artista_OID you are trying to unrelationer, doesn't exist in AlbumEN");

                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirFavorito (int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN albumEN = null;
        try
        {
                SessionInitializeTransaction ();
                albumEN = (AlbumEN)session.Load (typeof(AlbumNH), p_Album_OID);
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (albumEN.Usuario == null) {
                        albumEN.Usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                        usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                        usuarioENAux.Album_favoritos.Add (albumEN);

                        albumEN.Usuario.Add (usuarioENAux);
                }


                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarFavorito (int p_Album_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN albumEN = null;
                albumEN = (AlbumEN)session.Load (typeof(AlbumNH), p_Album_OID);

                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (albumEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                                if (albumEN.Usuario.Contains (usuarioENAux) == true) {
                                        albumEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Album_favoritos.Remove (albumEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in AlbumEN");
                        }
                }

                session.Update (albumEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesArtista (int p_id)
{
        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AlbumNH self where select alb FROM AlbumNH as alb inner join alb.Artista as art where art.Id = :p_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AlbumNHgetAlbumesArtistaHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> GetAlbumesFavsUsu (string p_email)
{
        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AlbumNH self where select alb FROM AlbumNH as alb inner join alb.Usuario as usu where usu.Email = :p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AlbumNHgetAlbumesFavsUsuHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in AlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
