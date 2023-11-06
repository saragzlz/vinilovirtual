
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
 * Clase Comunidad:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class ComunidadRepository : BasicRepository, IComunidadRepository
{
public ComunidadRepository() : base ()
{
}


public ComunidadRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComunidadEN ReadOIDDefault (int id
                                   )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComunidadNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                        else
                                result = session.CreateCriteria (typeof(ComunidadNH)).List<ComunidadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), comunidad.Id);


                comunidadNH.Nombre = comunidad.Nombre;


                comunidadNH.Imagen = comunidad.Imagen;


                comunidadNH.NumMiembros = comunidad.NumMiembros;


                session.Update (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComunidadEN comunidad)
{
        ComunidadNH comunidadNH = new ComunidadNH (comunidad);

        try
        {
                SessionInitializeTransaction ();

                session.Save (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidadNH.Id;
}

public void Modify (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), comunidad.Id);

                comunidadNH.Nombre = comunidad.Nombre;


                comunidadNH.Imagen = comunidad.Imagen;


                comunidadNH.NumMiembros = comunidad.NumMiembros;

                session.Update (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
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
                ComunidadNH comunidadNH = (ComunidadNH)session.Load (typeof(ComunidadNH), id);
                session.Delete (comunidadNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetID
//Con e: ComunidadEN
public ComunidadEN GetID (int id
                          )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComunidadNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                else
                        result = session.CreateCriteria (typeof(ComunidadNH)).List<ComunidadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void SeguirComunidad (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidadEN = null;
        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadNH), p_Comunidad_OID);
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario == null) {
                        comunidadEN.Usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
                }

                foreach (int item in p_usuario_OIDs) {
                        usuarioENAux = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                        usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                        usuarioENAux.Comunidad.Add (comunidadEN);

                        comunidadEN.Usuario.Add (usuarioENAux);
                }


                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AbandonarComunidad (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ComunidadEN comunidadEN = null;
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadNH), p_Comunidad_OID);

                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario != null) {
                        foreach (int item in p_usuario_OIDs) {
                                usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                                if (comunidadEN.Usuario.Contains (usuarioENAux) == true) {
                                        comunidadEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Comunidad.Remove (comunidadEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in ComunidadEN");
                        }
                }

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
