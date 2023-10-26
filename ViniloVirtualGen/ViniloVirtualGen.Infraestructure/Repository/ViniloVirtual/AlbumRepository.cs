
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

//Sin e: GiveId
//Con e: AlbumEN
public AlbumEN GiveId (int id
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

public System.Collections.Generic.IList<AlbumEN> GiveAll (int first, int size)
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
}
}
