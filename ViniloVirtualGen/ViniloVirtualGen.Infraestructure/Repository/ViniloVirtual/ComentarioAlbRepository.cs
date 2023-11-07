
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
 * Clase ComentarioAlb:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class ComentarioAlbRepository : BasicRepository, IComentarioAlbRepository
{
public ComentarioAlbRepository() : base ()
{
}


public ComentarioAlbRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComentarioAlbEN ReadOIDDefault (int id
                                       )
{
        ComentarioAlbEN comentarioAlbEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioAlbEN = (ComentarioAlbEN)session.Get (typeof(ComentarioAlbNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioAlbEN;
}

public System.Collections.Generic.IList<ComentarioAlbEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioAlbEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioAlbNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioAlbEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioAlbNH)).List<ComentarioAlbEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioAlbEN comentarioAlb)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioAlbNH comentarioAlbNH = (ComentarioAlbNH)session.Load (typeof(ComentarioAlbNH), comentarioAlb.Id);



                comentarioAlbNH.Texto = comentarioAlb.Texto;


                comentarioAlbNH.Fecha = comentarioAlb.Fecha;

                session.Update (comentarioAlbNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioAlbEN comentarioAlb)
{
        ComentarioAlbNH comentarioAlbNH = new ComentarioAlbNH (comentarioAlb);

        try
        {
                SessionInitializeTransaction ();
                if (comentarioAlb.Usuario != null) {
                        // Argumento OID y no colección.
                        comentarioAlbNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), comentarioAlb.Usuario.Email);

                        comentarioAlbNH.Usuario.ComentarioAlb
                        .Add (comentarioAlbNH);
                }
                if (comentarioAlb.Album != null) {
                        // Argumento OID y no colección.
                        comentarioAlbNH
                        .Album = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN), comentarioAlb.Album.Id);

                        comentarioAlbNH.Album.ComentarioAlb
                        .Add (comentarioAlbNH);
                }

                session.Save (comentarioAlbNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioAlbNH.Id;
}

public void Modify (ComentarioAlbEN comentarioAlb)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioAlbNH comentarioAlbNH = (ComentarioAlbNH)session.Load (typeof(ComentarioAlbNH), comentarioAlb.Id);

                comentarioAlbNH.Texto = comentarioAlb.Texto;


                comentarioAlbNH.Fecha = comentarioAlb.Fecha;

                session.Update (comentarioAlbNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
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
                ComentarioAlbNH comentarioAlbNH = (ComentarioAlbNH)session.Load (typeof(ComentarioAlbNH), id);
                session.Delete (comentarioAlbNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadID
//Con e: ComentarioAlbEN
public ComentarioAlbEN ReadID (int id
                               )
{
        ComentarioAlbEN comentarioAlbEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioAlbEN = (ComentarioAlbEN)session.Get (typeof(ComentarioAlbNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioAlbEN;
}

public System.Collections.Generic.IList<ComentarioAlbEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioAlbEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioAlbNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioAlbEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioAlbNH)).List<ComentarioAlbEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioAlbRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
