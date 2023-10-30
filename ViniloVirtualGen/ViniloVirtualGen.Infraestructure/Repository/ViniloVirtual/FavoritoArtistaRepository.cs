
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
 * Clase FavoritoArtista:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class FavoritoArtistaRepository : BasicRepository, IFavoritoArtistaRepository
{
public FavoritoArtistaRepository() : base ()
{
}


public FavoritoArtistaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoArtistaEN ReadOIDDefault (int id
                                         )
{
        FavoritoArtistaEN favoritoArtistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoArtistaEN = (FavoritoArtistaEN)session.Get (typeof(FavoritoArtistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoArtistaEN;
}

public System.Collections.Generic.IList<FavoritoArtistaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoArtistaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoArtistaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoArtistaEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoArtistaNH)).List<FavoritoArtistaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoArtistaEN favoritoArtista)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoArtistaNH favoritoArtistaNH = (FavoritoArtistaNH)session.Load (typeof(FavoritoArtistaNH), favoritoArtista.Id);


                session.Update (favoritoArtistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FavoritoArtistaEN favoritoArtista)
{
        FavoritoArtistaNH favoritoArtistaNH = new FavoritoArtistaNH (favoritoArtista);

        try
        {
                SessionInitializeTransaction ();
                if (favoritoArtista.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoArtistaNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), favoritoArtista.Usuario.Id);

                        favoritoArtistaNH.Usuario.FavoritoArtista
                        .Add (favoritoArtistaNH);
                }
                if (favoritoArtista.Artista != null) {
                        // Argumento OID y no colección.
                        favoritoArtistaNH
                        .Artista = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN), favoritoArtista.Artista.Id);

                        favoritoArtistaNH.Artista.FavoritoArtista
                        .Add (favoritoArtistaNH);
                }

                session.Save (favoritoArtistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoArtistaNH.Id;
}

public void Modify (FavoritoArtistaEN favoritoArtista)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoArtistaNH favoritoArtistaNH = (FavoritoArtistaNH)session.Load (typeof(FavoritoArtistaNH), favoritoArtista.Id);
                session.Update (favoritoArtistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
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
                FavoritoArtistaNH favoritoArtistaNH = (FavoritoArtistaNH)session.Load (typeof(FavoritoArtistaNH), id);
                session.Delete (favoritoArtistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: FavoritoArtistaEN
public FavoritoArtistaEN ReadOID (int id
                                  )
{
        FavoritoArtistaEN favoritoArtistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoArtistaEN = (FavoritoArtistaEN)session.Get (typeof(FavoritoArtistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoArtistaEN;
}

public System.Collections.Generic.IList<FavoritoArtistaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritoArtistaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoArtistaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoArtistaEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoArtistaNH)).List<FavoritoArtistaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
