
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
 * Clase Comentario:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class ComentarioRepository : BasicRepository, IComentarioRepository
{
public ComentarioRepository() : base ()
{
}


public ComentarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComentarioEN ReadOIDDefault (int id
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.Texto = comentario.Texto;




                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        ComentarioNH comentarioNH = new ComentarioNH (comentario);

        try
        {
                SessionInitializeTransaction ();
                if (comentario.Album != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Album = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN), comentario.Album.Id);

                        comentarioNH.Album.Comentario
                        .Add (comentarioNH);
                }
                if (comentario.Comunidad != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Comunidad = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN), comentario.Comunidad.Id);

                        comentarioNH.Comunidad.Comentario
                        .Add (comentarioNH);
                }
                if (comentario.Usuario != null) {
                        // Argumento OID y no colección.
                        comentarioNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), comentario.Usuario.Email);

                        comentarioNH.Usuario.Comentario
                        .Add (comentarioNH);
                }

                session.Save (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioNH.Id;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), comentario.Id);

                comentarioNH.Texto = comentario.Texto;

                session.Update (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
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
                ComentarioNH comentarioNH = (ComentarioNH)session.Load (typeof(ComentarioNH), id);
                session.Delete (comentarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetID
//Con e: ComentarioEN
public ComentarioEN GetID (int id
                           )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioNH)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
