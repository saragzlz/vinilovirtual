
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
 * Clase LineaPedido:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
public partial class LineaPedidoRepository : BasicRepository, ILineaPedidoRepository
{
public LineaPedidoRepository() : base ()
{
}


public LineaPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaPedidoEN ReadOIDDefault (int id
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Id);

                lineaPedidoNH.Precio = lineaPedido.Precio;



                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaPedidoEN lineaPedido)
{
        LineaPedidoNH lineaPedidoNH = new LineaPedidoNH (lineaPedido);

        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Pedido = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN), lineaPedido.Pedido.Id);

                        lineaPedidoNH.Pedido.LineaPedido
                        .Add (lineaPedidoNH);
                }
                if (lineaPedido.Album != null) {
                        // Argumento OID y no colección.
                        lineaPedidoNH
                        .Album = (ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN)session.Load (typeof(ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.AlbumEN), lineaPedido.Album.Id);

                        lineaPedidoNH.Album.LineaPedido
                        .Add (lineaPedidoNH);
                }

                session.Save (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoNH.Id;
}

public void Modify (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), lineaPedido.Id);

                lineaPedidoNH.Precio = lineaPedido.Precio;

                session.Update (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
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
                LineaPedidoNH lineaPedidoNH = (LineaPedidoNH)session.Load (typeof(LineaPedidoNH), id);
                session.Delete (lineaPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetID
//Con e: LineaPedidoEN
public LineaPedidoEN GetID (int id
                            )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPedidoNH)).List<LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
