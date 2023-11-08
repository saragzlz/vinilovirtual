
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
 * Clase ComentarioCom:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class ComentarioComRepository : BasicRepository, IComentarioComRepository
{
public ComentarioComRepository() : base ()
{
}


public ComentarioComRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComentarioComEN ReadOIDDefault (int id
                                       )
{
        ComentarioComEN comentarioComEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioComEN = (ComentarioComEN)session.Get (typeof(ComentarioComNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioComEN;
}

public System.Collections.Generic.IList<ComentarioComEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioComEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioComNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioComEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioComNH)).List<ComentarioComEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioComEN comentarioCom)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioComNH comentarioComNH = (ComentarioComNH)session.Load (typeof(ComentarioComNH), comentarioCom.Id);



                comentarioComNH.Texto = comentarioCom.Texto;


                comentarioComNH.Fecha = comentarioCom.Fecha;

                session.Update (comentarioComNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioComEN comentarioCom)
{
        ComentarioComNH comentarioComNH = new ComentarioComNH (comentarioCom);

        try
        {
                SessionInitializeTransaction ();
                if (comentarioCom.Usuario != null) {
                        // Argumento OID y no colección.
                        comentarioComNH
                        .Usuario = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN), comentarioCom.Usuario.Email);

                        comentarioComNH.Usuario.ComentarioCom
                        .Add (comentarioComNH);
                }
                if (comentarioCom.Comunidad != null) {
                        // Argumento OID y no colección.
                        comentarioComNH
                        .Comunidad = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN), comentarioCom.Comunidad.Id);

                        comentarioComNH.Comunidad.ComentarioCom
                        .Add (comentarioComNH);
                }

                session.Save (comentarioComNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioComNH.Id;
}

public void Modify (ComentarioComEN comentarioCom)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioComNH comentarioComNH = (ComentarioComNH)session.Load (typeof(ComentarioComNH), comentarioCom.Id);

                comentarioComNH.Texto = comentarioCom.Texto;


                comentarioComNH.Fecha = comentarioCom.Fecha;

                session.Update (comentarioComNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
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
                ComentarioComNH comentarioComNH = (ComentarioComNH)session.Load (typeof(ComentarioComNH), id);
                session.Delete (comentarioComNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentarioComEN
public ComentarioComEN ReadOID (int id
                                )
{
        ComentarioComEN comentarioComEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioComEN = (ComentarioComEN)session.Get (typeof(ComentarioComNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comentarioComEN;
}

public System.Collections.Generic.IList<ComentarioComEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioComEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioComNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioComEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioComNH)).List<ComentarioComEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> GetComentariosComunidad (int p_id)
{
        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioComNH self where select comm FROM ComentarioComNH as comm inner join comm.Comunidad as com where com.Id= :p_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioComNHgetComentariosComunidadHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> GetCommentsComunidadUsu (string p_email)
{
        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioComNH self where select comm FROM ComentarioComNH as comm inner join comm.Usuario as usu where usu.Email = :p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioComNHgetCommentsComunidadUsuHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComentarioComEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComentarioComRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
