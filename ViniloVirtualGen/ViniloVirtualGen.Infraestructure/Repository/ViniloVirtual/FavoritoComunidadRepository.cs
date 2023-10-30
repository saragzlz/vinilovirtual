
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
 * Clase FavoritoComunidad:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class FavoritoComunidadRepository : BasicRepository, IFavoritoComunidadRepository
{
public FavoritoComunidadRepository() : base ()
{
}


public FavoritoComunidadRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoComunidadEN ReadOIDDefault (int id
                                           )
{
        FavoritoComunidadEN favoritoComunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoComunidadEN = (FavoritoComunidadEN)session.Get (typeof(FavoritoComunidadNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoComunidadEN;
}

public System.Collections.Generic.IList<FavoritoComunidadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoComunidadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoComunidadNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoComunidadEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoComunidadNH)).List<FavoritoComunidadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoComunidadEN favoritoComunidad)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoComunidadNH favoritoComunidadNH = (FavoritoComunidadNH)session.Load (typeof(FavoritoComunidadNH), favoritoComunidad.Id);


                session.Update (favoritoComunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FavoritoComunidadEN favoritoComunidad)
{
        FavoritoComunidadNH favoritoComunidadNH = new FavoritoComunidadNH (favoritoComunidad);

        try
        {
                SessionInitializeTransaction ();
                if (favoritoComunidad.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoComunidadNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), favoritoComunidad.Usuario.Id);

                        favoritoComunidadNH.Usuario.FavoritoComunidad
                        .Add (favoritoComunidadNH);
                }
                if (favoritoComunidad.Comunidad != null) {
                        // Argumento OID y no colección.
                        favoritoComunidadNH
                        .Comunidad = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN), favoritoComunidad.Comunidad.Id);

                        favoritoComunidadNH.Comunidad.FavoritoComunidad
                        .Add (favoritoComunidadNH);
                }

                session.Save (favoritoComunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoComunidadNH.Id;
}

public void Modify (FavoritoComunidadEN favoritoComunidad)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoComunidadNH favoritoComunidadNH = (FavoritoComunidadNH)session.Load (typeof(FavoritoComunidadNH), favoritoComunidad.Id);
                session.Update (favoritoComunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
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
                FavoritoComunidadNH favoritoComunidadNH = (FavoritoComunidadNH)session.Load (typeof(FavoritoComunidadNH), id);
                session.Delete (favoritoComunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: FavoritoComunidadEN
public FavoritoComunidadEN ReadOID (int id
                                    )
{
        FavoritoComunidadEN favoritoComunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoComunidadEN = (FavoritoComunidadEN)session.Get (typeof(FavoritoComunidadNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoComunidadEN;
}

public System.Collections.Generic.IList<FavoritoComunidadEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoComunidadEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoComunidadNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoComunidadEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoComunidadNH)).List<FavoritoComunidadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
