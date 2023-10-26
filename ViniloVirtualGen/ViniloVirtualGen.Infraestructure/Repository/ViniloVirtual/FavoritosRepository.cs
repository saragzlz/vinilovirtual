
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
 * Clase Favoritos:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class FavoritosRepository : BasicRepository, IFavoritosRepository
{
public FavoritosRepository() : base ()
{
}


public FavoritosRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritosEN ReadOIDDefault (int id
                                   )
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritosNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritosNH)).List<FavoritosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritosEN favoritos)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), favoritos.Id);
                session.Update (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FavoritosEN favoritos)
{
        FavoritosNH favoritosNH = new FavoritosNH (favoritos);

        try
        {
                SessionInitializeTransaction ();

                session.Save (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritosNH.Id;
}

public void Modify (FavoritosEN favoritos)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), favoritos.Id);
                session.Update (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
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
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), id);
                session.Delete (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GiveId
//Con e: FavoritosEN
public FavoritosEN GiveId (int id
                           )
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> GiveAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritosNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritosNH)).List<FavoritosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
