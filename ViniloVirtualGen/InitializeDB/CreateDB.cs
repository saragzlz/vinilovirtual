
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.CP;
using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                AdminRepository adminrepository = new AdminRepository ();
                AdminCEN admincen = new AdminCEN (adminrepository);
                AlbumRepository albumrepository = new AlbumRepository ();
                AlbumCEN albumcen = new AlbumCEN (albumrepository);
                ArtistaRepository artistarepository = new ArtistaRepository ();
                ArtistaCEN artistacen = new ArtistaCEN (artistarepository);
                ComunidadRepository comunidadrepository = new ComunidadRepository ();
                ComunidadCEN comunidadcen = new ComunidadCEN (comunidadrepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                LineaPedidoRepository lineapedidorepository = new LineaPedidoRepository ();
                LineaPedidoCEN lineapedidocen = new LineaPedidoCEN (lineapedidorepository);
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                ComentarioAlbRepository comentarioalbrepository = new ComentarioAlbRepository ();
                ComentarioAlbCEN comentarioalbcen = new ComentarioAlbCEN (comentarioalbrepository);
                ComentarioComRepository comentariocomrepository = new ComentarioComRepository ();
                ComentarioComCEN comentariocomcen = new ComentarioComCEN (comentariocomrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                //Cracion de INSTANCIAS
                //Creacion de usuarios
                string usuario1 = usuariocen.New_ ("ablarb", "0000", "alvaro@gmail.com", new DateTime (2000, 10, 23),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.masculino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "fallo");
                string usuario2 = usuariocen.New_ ("Sara", "1313", "sara@gmail.com", new DateTime (1998, 06, 10),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.femenino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "perfil2.jpg");
                string usuario3 = usuariocen.New_ ("Guillermo", "1414", "guille@gmail.com", new DateTime (2000, 06, 14),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.masculino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "perfil3.jpg");
                Console.WriteLine (" ");
                Console.WriteLine ("Usuario " + usuario1 + " creado correctamente");
                Console.WriteLine ("Usuario " + usuario2 + " creado correctamente");
                Console.WriteLine ("Usuario " + usuario3 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de artistas
                int artista1 = artistacen.New_ ("Her's",
                        "Her's fue una banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros",
                        "fallo.jpg"
                        );
                int artista2 = artistacen.New_ ("Gorillaz",
                        "Banda virtual inglesa creada en 1998 por Damon Albarn y Jamie Hewlett. La banda está compuesta por cuatro miembros ficticios",
                        "artista2.jpg"
                        );
                Console.WriteLine (" ");
                Console.WriteLine ("Artista " + artista1 + " creado correctamente");
                Console.WriteLine ("Artista " + artista2 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de albumes
                int album1 = albumcen.New_ ("Invitation to Her's", "Segundo album de la banda Her's",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "portada1.jpg", artista1,
                        6.00);

                int album2 = albumcen.New_ ("Plastic Beach", "Tercer album de la banda Gorillaz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rock, "portada2.jpg", artista2,
                        7.99);
                int album3 = albumcen.New_ ("Song of Her's", "Primer album de la banda Her's",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "portada3.jpg", artista1,
                        41.43);
                Console.WriteLine (" ");
                Console.WriteLine ("Album " + album1 + " creado correctamente");
                Console.WriteLine ("Album " + album2 + " creado correctamente");
                Console.WriteLine ("Album " + album3 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de comunidades
                int comunidad1 = comunidadcen.New_ ("Locos por el Jazz", "comunidad1.jpg", 15);
                int comunidad2 = comunidadcen.New_ ("Rock and Stone", "comunidad2.jpg", 47);
                int comunidad3 = comunidadcen.New_ ("Beats", "comunidad3.jpg", 73);


                //Creacion de Comentarios de Albumes
                int comentarioAlb1 = comentarioalbcen.New_ (usuario1, album1,
                        "Mi cancion favorita es de este album. Nunca me canso de escucharlo",
                        new DateTime (2023, 11, 07));
                int comentarioAlb2 = comentarioalbcen.New_ (usuario1, album3,
                        "El mejor album de debut que se haya hecho",
                        new DateTime (2023, 11, 07));
                int comentarioAlb3 = comentarioalbcen.New_ (usuario2, album2,
                        "Esta bien, pero podria se mejor",
                        new DateTime (2023, 10, 07));

                //Creacion de comentarios de comunidades
                int comentarioCom1 = comentariocomcen.New_ (usuario1, comunidad1,
                        "Ojalá el jazz renaciese",
                        new DateTime (2023, 11, 07));
                int comentarioCom2 = comentariocomcen.New_ (usuario1, comunidad2,
                        "Como me gusta el Rock",
                        new DateTime (2023, 11, 07));
                int comentarioCom3 = comentariocomcen.New_ (usuario2, comunidad3,
                        "Me encanta el rap, me activa para pasar el dia",
                        new DateTime (2023, 11, 07));



                //Probar CUSTOMS
                //USUARIO
                //Modificamos el estado a "2", equivalente a "baneado temporal"
                usuariocen.ModificarEstado ("alvaro@gmail.com", 2);
                //Modificamos el nombre del usuario
                usuariocen.ModificarNombre ("alvaro@gmail.com", "Alvaro");
                //Modificamos la imagen del usuario
                usuariocen.ModificarImagen ("alvaro@gmail.com", "perfil1.jpg");

                UsuarioEN usuarioen1 = usuariorepository.GetID (usuario1);

                Console.WriteLine (" ");
                Console.WriteLine ("Estado de " + usuario1 + " cambiado a: " + usuarioen1.Estado);
                Console.WriteLine ("Nombre de " + usuario1 + " cambiado a: " + usuarioen1.Nombre);
                Console.WriteLine ("Imagen de perfil de " + usuario1 + " cambiado a: " + usuarioen1.Imagen);
                Console.WriteLine (" ");


                //ALBUM
                //Modificamos el precio del album
                albumcen.ModificarPrecio (album1, 21.42);

                AlbumEN albumen1 = albumrepository.GetID (album1);

                Console.WriteLine (" ");
                Console.WriteLine ("Precio del album " + album1 + " cambiado a: " + albumen1.Precio);
                Console.WriteLine (" ");


                //ARTISTA

                //Modificamos la descripcion del artista
                artistacen.ModificarDescripcion (artista1, "Banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros");

                //Modificamos la imagen del artista
                artistacen.ModificarImagen (artista1, "artista1.jpg");

                /* Esta no funciona, el metodo no cambia correctamente la contraseña. Seguramente por temas de encriptado.
                 * //Modificamos la password e iniciamos sesion
                 * usuariocen.ModificarPass ("alvaro@gmail.com", "1212");
                 * if (usuariocen.Login ("alvaro@gmail.com", "1212") != null) {
                 *      Console.WriteLine ("Usuario loggeado");
                 * }*/

                ArtistaEN artistaen1 = artistarepository.GetID (artista1);

                Console.WriteLine (" ");
                Console.WriteLine ("Descripcion del artista " + artista1 + " cambiada a: " + artistaen1.Descripcion);
                Console.WriteLine ("Imagen del artista " + artista1 + " cambiada a: " + artistaen1.Imagen);
                Console.WriteLine (" ");


                //Probar FILTERS

                // FILTRO PARA COMPROBAR LOS USUARIOS CON UN ESTADO ESPECIFICO
                IList<UsuarioEN> listaUsuariosEstado =
                        usuariocen.GetUsuariosEstado (ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los usuarios con determinado estado ");

                foreach (UsuarioEN usuario in listaUsuariosEstado) { // recorrer la lista
                        Console.WriteLine ("El usuario: " + usuario.Email + " . De nombre: " + usuario.Nombre);
                }
                Console.WriteLine (" ");

                // FILTRO PARA COMPROBAR LOS ALBUMES DE UN ARTISTA ESPECIFICO
                IList<AlbumEN> listaAlbumesArtista = albumcen.GetAlbumesArtista (32768);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los albumes del artista con id 32768 ");

                foreach (AlbumEN album in listaAlbumesArtista) { // recorrer la lista
                        Console.WriteLine ("Album " + album.Nombre + " con ID " + album.Id);
                }
                Console.WriteLine (" ");

                // FILTROS DE COMENTARIOS -----------------------------------------------------------------------------
                // FILTRO PARA COMPROBAR LOS COMENTARIOS DE UN ALBUM ESPECIFICO
                IList<ComentarioAlbEN> listaCommentsAlbum = comentarioalbcen.GetComentariosAlbum (album2);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los comentarios del album con id " + album2);

                foreach (ComentarioAlbEN comentario in listaCommentsAlbum) { // recorrer la lista
                        Console.WriteLine ("Comentario: " + comentario.Id + ": " + comentario.Texto);
                }
                Console.WriteLine (" ");

                // FILTRO PARA COMPROBAR LOS COMENTARIOS DE UNA COMUNIDAD ESPECIFICO
                IList<ComentarioComEN> listaCommentsComunidad = comentariocomcen.GetComentariosComunidad (comunidad3);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los comentarios de la comunidad con id " + comunidad3);

                foreach (ComentarioComEN comentario in listaCommentsComunidad) { // recorrer la lista
                        Console.WriteLine ("Comentario " + comentario.Id + ": " + comentario.Texto);
                }
                Console.WriteLine (" ");

                // FILTROS DE USUARIOS -----------------------------------------------------------------------------
                // FILTRO PARA COMPROBAR LOS PEDIDOS DE UN USUARIO EN ESPECIFICO
                IList<PedidoEN> listaPedidosUsuario = pedidocen.GetPedidosUsu (usuario1);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los pedidos del usuario con email: " + usuario1);

                foreach (PedidoEN pedido in listaPedidosUsuario) { // recorrer la lista
                        Console.WriteLine ("Pedido " + pedido.Id + " con estado " + pedido.Estado);
                }
                Console.WriteLine (" ");

                // FILTROS DE FAVORITOS -----------------------------------------------------------------------------
                // FILTRO PARA COMPROBAR LOS ALBUMES FAVORITOS DE UN USUARIO EN ESPECIFICO
                IList<AlbumEN> listaAlbumesFavs = albumcen.GetAlbumesFavsUsu (usuario2);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los ALBUMES FAVORITOS de email: " + usuario2);

                foreach (AlbumEN album in listaAlbumesFavs) { // recorrer la lista
                        Console.WriteLine ("Album " + album.Nombre);
                }
                Console.WriteLine (" ");

                // FILTRO PARA COMPROBAR LOS ARTISTAS FAVORITOS DE UN USUARIO EN ESPECIFICO
                IList<ArtistaEN> listaArtistasFavs = artistacen.GetArtistasFavsUsu(usuario1);

                Console.WriteLine (" ");
                Console.WriteLine("Consulta de los ARTISTAS FAVORITOS de email: " + usuario1);

                foreach (ArtistaEN artista in listaArtistasFavs)
                { // recorrer la lista
                    Console.WriteLine("Artista " + artista.Nombre);
                }

                Console.WriteLine(" ");
                    
                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
