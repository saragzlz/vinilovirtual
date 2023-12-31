
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
 * Clase Usuario:
 *
 */

namespace ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual
{
        public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
        {
                public UsuarioRepository() : base()
                {
                }


                public UsuarioRepository(GenericSessionCP sessionAux) : base(sessionAux)
                {
                }


                public void setSessionCP(GenericSessionCP session)
                {
                        sessionInside = false;
                        this.session = (ISession)session.CurrentSession;
                }


                public UsuarioEN ReadOIDDefault(string email
                                                 )
                {
                        UsuarioEN usuarioEN = null;

                        try
                        {
                                SessionInitializeTransaction();
                                usuarioEN = (UsuarioEN)session.Get(typeof(UsuarioNH), email);
                                SessionCommit();
                        }

                        catch (Exception)
                        {
                        }


                        finally
                        {
                                SessionClose();
                        }

                        return usuarioEN;
                }

                public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault(int first, int size)
                {
                        System.Collections.Generic.IList<UsuarioEN> result = null;
                        try
                        {
                                using (ITransaction tx = session.BeginTransaction())
                                {
                                        if (size > 0)
                                                result = session.CreateCriteria(typeof(UsuarioNH)).
                                                         SetFirstResult(first).SetMaxResults(size).List<UsuarioEN>();
                                        else
                                                result = session.CreateCriteria(typeof(UsuarioNH)).List<UsuarioEN>();
                                }
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }

                        return result;
                }

                // Modify default (Update all attributes of the class)

                public void ModifyDefault(UsuarioEN usuario)
                {
                        try
                        {
                                SessionInitializeTransaction();
                                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), usuario.Email);

                                usuarioNH.Nombre = usuario.Nombre;


                                usuarioNH.Pass = usuario.Pass;


                                usuarioNH.FechaNac = usuario.FechaNac;


                                usuarioNH.Genero = usuario.Genero;


                                usuarioNH.Estado = usuario.Estado;


                                usuarioNH.Imagen = usuario.Imagen;









                                usuarioNH.Apellido = usuario.Apellido;


                                usuarioNH.Tipo = usuario.Tipo;

                                session.Update(usuarioNH);
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }
                }


                public string New_(UsuarioEN usuario)
                {
                        UsuarioNH usuarioNH = new UsuarioNH(usuario);

                        try
                        {
                                SessionInitializeTransaction();

                                session.Save(usuarioNH);
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }

                        return usuarioNH.Email;
                }

                public void AddAlbumBuy(UsuarioEN usuario)
                {
                        try
                        {
                                SessionInitializeTransaction();
                                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), usuario.Email);
                                if (usuarioNH.Album.Count > 0)
                                {
                                        foreach (AlbumEN x in usuario.Album)
                                        {
                                                if (!usuarioNH.Album.Contains(x))
                                                {
                                                        usuarioNH.Album.Add(x);
                                                }

                                        }
                                }
                                else
                                {
                                        usuarioNH.Album = usuario.Album;
                                }

                                session.Update(usuarioNH);
                                SessionCommit();
                        }
                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }
                }

                public void Modify(UsuarioEN usuario)
                {
                        try
                        {
                                SessionInitializeTransaction();
                                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), usuario.Email);

                                usuarioNH.Nombre = usuario.Nombre;


                                usuarioNH.Pass = usuario.Pass;


                                usuarioNH.FechaNac = usuario.FechaNac;


                                usuarioNH.Genero = usuario.Genero;


                                usuarioNH.Estado = usuario.Estado;


                                usuarioNH.Imagen = usuario.Imagen;


                                usuarioNH.Apellido = usuario.Apellido;


                                usuarioNH.Tipo = usuario.Tipo;

                                session.Update(usuarioNH);
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }
                }
                public void Destroy(string email
                                     )
                {
                        try
                        {
                                SessionInitializeTransaction();
                                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), email);
                                session.Delete(usuarioNH);
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }
                }

                //Sin e: GetID
                //Con e: UsuarioEN
                public UsuarioEN GetID(string email
                                        )
                {
                        UsuarioEN usuarioEN = null;

                        try
                        {
                                SessionInitializeTransaction();
                                usuarioEN = (UsuarioEN)session.Get(typeof(UsuarioNH), email);
                                SessionCommit();
                        }

                        catch (Exception)
                        {
                        }


                        finally
                        {
                                SessionClose();
                        }

                        return usuarioEN;
                }

                public System.Collections.Generic.IList<UsuarioEN> ReadAll(int first, int size)
                {
                        System.Collections.Generic.IList<UsuarioEN> result = null;
                        try
                        {
                                SessionInitializeTransaction();
                                if (size > 0)
                                        result = session.CreateCriteria(typeof(UsuarioNH)).
                                                 SetFirstResult(first).SetMaxResults(size).List<UsuarioEN>();
                                else
                                        result = session.CreateCriteria(typeof(UsuarioNH)).List<UsuarioEN>();
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }

                        return result;
                }

                public System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> GetUsuariosEstado(ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum? p_estado)
                {
                        System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN> result;
                        try
                        {
                                SessionInitializeTransaction();
                                //String sql = @"FROM UsuarioNH self where Select usu FROM UsuarioNH as usu where usu.Estado = :p_estado";
                                //IQuery query = session.CreateQuery(sql);
                                IQuery query = (IQuery)session.GetNamedQuery("UsuarioNHgetUsuariosEstadoHQL");
                                query.SetParameter("p_estado", p_estado);

                                result = query.List<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.UsuarioEN>();
                                SessionCommit();
                        }

                        catch (Exception ex)
                        {
                                SessionRollBack();
                                if (ex is ViniloVirtualGen.ApplicationCore.Exceptions.ModelException)
                                        throw;
                                else throw new ViniloVirtualGen.ApplicationCore.Exceptions.DataLayerException("Error in UsuarioRepository.", ex);
                        }


                        finally
                        {
                                SessionClose();
                        }

                        return result;
                }
        }
}
