
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
 * Clase FavoritoAlbum:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class FavoritoAlbumRepository : BasicRepository, IFavoritoAlbumRepository
{
public FavoritoAlbumRepository() : base ()
{
}


public FavoritoAlbumRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoAlbumEN ReadOIDDefault (int id
                                       )
{
        FavoritoAlbumEN favoritoAlbumEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoAlbumEN = (FavoritoAlbumEN)session.Get (typeof(FavoritoAlbumNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoAlbumEN;
}

public System.Collections.Generic.IList<FavoritoAlbumEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoAlbumEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoAlbumNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoAlbumEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoAlbumNH)).List<FavoritoAlbumEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoAlbumEN favoritoAlbum)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoAlbumNH favoritoAlbumNH = (FavoritoAlbumNH)session.Load (typeof(FavoritoAlbumNH), favoritoAlbum.Id);


                session.Update (favoritoAlbumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FavoritoAlbumEN favoritoAlbum)
{
        FavoritoAlbumNH favoritoAlbumNH = new FavoritoAlbumNH (favoritoAlbum);

        try
        {
                SessionInitializeTransaction ();
                if (favoritoAlbum.Album != null) {
                        // Argumento OID y no colección.
                        favoritoAlbumNH
                        .Album = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN), favoritoAlbum.Album.Id);

                        favoritoAlbumNH.Album.Favoritos
                        .Add (favoritoAlbumNH);
                }
                if (favoritoAlbum.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoAlbumNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), favoritoAlbum.Usuario.Id);

                        favoritoAlbumNH.Usuario.FavoritoAlbum
                        .Add (favoritoAlbumNH);
                }

                session.Save (favoritoAlbumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoAlbumNH.Id;
}

public void Modify (FavoritoAlbumEN favoritoAlbum)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoAlbumNH favoritoAlbumNH = (FavoritoAlbumNH)session.Load (typeof(FavoritoAlbumNH), favoritoAlbum.Id);
                session.Update (favoritoAlbumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
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
                FavoritoAlbumNH favoritoAlbumNH = (FavoritoAlbumNH)session.Load (typeof(FavoritoAlbumNH), id);
                session.Delete (favoritoAlbumNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GiveId
//Con e: FavoritoAlbumEN
public FavoritoAlbumEN GiveId (int id
                               )
{
        FavoritoAlbumEN favoritoAlbumEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoAlbumEN = (FavoritoAlbumEN)session.Get (typeof(FavoritoAlbumNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoAlbumEN;
}

public System.Collections.Generic.IList<FavoritoAlbumEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoAlbumEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoAlbumNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoAlbumEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoAlbumNH)).List<FavoritoAlbumEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoAlbumRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
