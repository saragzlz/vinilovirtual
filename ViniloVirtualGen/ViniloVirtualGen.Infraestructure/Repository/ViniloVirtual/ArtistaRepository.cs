
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
 * Clase Artista:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class ArtistaRepository : BasicRepository, IArtistaRepository
{
public ArtistaRepository() : base ()
{
}


public ArtistaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ArtistaEN ReadOIDDefault (int id
                                 )
{
        ArtistaEN artistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                artistaEN = (ArtistaEN)session.Get (typeof(ArtistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return artistaEN;
}

public System.Collections.Generic.IList<ArtistaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArtistaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArtistaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArtistaEN>();
                        else
                                result = session.CreateCriteria (typeof(ArtistaNH)).List<ArtistaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArtistaEN artista)
{
        try
        {
                SessionInitializeTransaction ();
                ArtistaNH artistaNH = (ArtistaNH)session.Load (typeof(ArtistaNH), artista.Id);

                artistaNH.Nombre = artista.Nombre;


                artistaNH.Descripcion = artista.Descripcion;


                artistaNH.Imagen = artista.Imagen;



                session.Update (artistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ArtistaEN artista)
{
        ArtistaNH artistaNH = new ArtistaNH (artista);

        try
        {
                SessionInitializeTransaction ();

                session.Save (artistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return artistaNH.Id;
}

public void Modify (ArtistaEN artista)
{
        try
        {
                SessionInitializeTransaction ();
                ArtistaNH artistaNH = (ArtistaNH)session.Load (typeof(ArtistaNH), artista.Id);

                artistaNH.Nombre = artista.Nombre;


                artistaNH.Descripcion = artista.Descripcion;


                artistaNH.Imagen = artista.Imagen;

                session.Update (artistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
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
                ArtistaNH artistaNH = (ArtistaNH)session.Load (typeof(ArtistaNH), id);
                session.Delete (artistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetID
//Con e: ArtistaEN
public ArtistaEN GetID (int id
                        )
{
        ArtistaEN artistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                artistaEN = (ArtistaEN)session.Get (typeof(ArtistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return artistaEN;
}

public System.Collections.Generic.IList<ArtistaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ArtistaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ArtistaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ArtistaEN>();
                else
                        result = session.CreateCriteria (typeof(ArtistaNH)).List<ArtistaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirFavorito (int p_Artista_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artistaEN = null;
        try
        {
                SessionInitializeTransaction ();
                artistaEN = (ArtistaEN)session.Load (typeof(ArtistaNH), p_Artista_OID);
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (artistaEN.Usuario == null) {
                        artistaEN.Usuario = new System.Collections.Generic.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
                }

                foreach (string item in p_usuario_OIDs) {
                        usuarioENAux = new ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN ();
                        usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                        usuarioENAux.Artista_favoritos.Add (artistaEN);

                        artistaEN.Usuario.Add (usuarioENAux);
                }


                session.Update (artistaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarFavorito (int p_Artista_OID, System.Collections.Generic.IList<string> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN artistaEN = null;
                artistaEN = (ArtistaEN)session.Load (typeof(ArtistaNH), p_Artista_OID);

                ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN usuarioENAux = null;
                if (artistaEN.Usuario != null) {
                        foreach (string item in p_usuario_OIDs) {
                                usuarioENAux = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN)session.Load (typeof(ViniloVirtualGen.Infraestructure.EN.ViniloVirtual.UsuarioNH), item);
                                if (artistaEN.Usuario.Contains (usuarioENAux) == true) {
                                        artistaEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Artista_favoritos.Remove (artistaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in ArtistaEN");
                        }
                }

                session.Update (artistaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> GetArtistasFavsUsu (string p_email)
{
        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArtistaNH self where select art FROM ArtistaNH as art inner join art.Usuario as usu where usu.Email = :p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArtistaNHgetArtistasFavsUsuHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.ArtistaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArtistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
