
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
using System.Timers;

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
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "fallo", "Sanz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);
                string usuario2 = usuariocen.New_ ("Sara", "1313", "sara@gmail.com", new DateTime (1998, 06, 10),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.femenino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "/Images/sara.PNG", "Ródenas",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);
                string usuario3 = usuariocen.New_ ("Guillermo", "1414", "guille@gmail.com", new DateTime (2000, 06, 14),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.masculino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "/Images/guille.PNG", "Puerta",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);
                Console.WriteLine (" ");
                Console.WriteLine ("Usuario " + usuario1 + " creado correctamente");
                Console.WriteLine ("Usuario " + usuario2 + " creado correctamente");
                Console.WriteLine ("Usuario " + usuario3 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de administrador
                string admin1 = usuariocen.New_ ("DSM", "9999", "dsm@gmail.com", new DateTime (2024, 09, 01),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.nB,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "/Images/dsm.jpg", "Administrador",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.administrador);
                Console.WriteLine (" ");
                Console.WriteLine ("Usuario " + admin1 + " creado correctamente");
                UsuarioEN adminen1 = usuariorepository.GetID (admin1);
                Console.WriteLine ("Los derechos de " + admin1 + " son: " + adminen1.Tipo);

                Console.WriteLine (" ");
                //Creacion de artistas
                int artista1 = artistacen.New_ ("Her's",
                        "Her's fue una banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros",
                        "fallo.jpg"
                        );
                int artista2 = artistacen.New_ ("Gorillaz",
                        "Banda virtual inglesa creada en 1998 por Damon Albarn y Jamie Hewlett. La banda está compuesta por cuatro miembros ficticios",
                        "/Images/gorillaz.jpg"
                        );
                int artista3 = artistacen.New_ ("Kill Bill: The Rapper",
                        "Tambien conocido como Bill, es un rapero Americano centrado en producir hip-hop",
                        "/Images/killbill.PNG"
                        );
                int artista4 = artistacen.New_ ("Berlioz",
                        "Banda de dos integrantes que experimenta de nuevas formas el jazz",
                        "/Images/berlioz.jpg"
                        );
                int artista5 = artistacen.New_ ("Andrew Prahlow",
                        "Compositor de bandas sonoras que saltó a la fama tras su ultimo trabajo, Outer Wilds OST",
                        "/Images/andrew.jpg"
                        );
                int artista6 = artistacen.New_ ("Guitarricadelafuente",
                        "Álvaro Lafuente Calvo, ​ conocido artísticamente como Guitarricadelafuente, es un cantautor, compositor y músico español",
                        "/Images/guitarrica.jpg"
                        );
                int artista7 = artistacen.New_ ("Cruz Cafune",
                        "Carlos Bruñas Zamorín, de nombre artístico Cruz Cafuné, es un cantante y rapero canario",
                        "/Images/crusi.jpg"
                        );
                int artista8 = artistacen.New_ ("Dua Lipa",
                        "Dua Lipa es una cantante, compositora y modelo británicoalbanesa. Después de trabajar como modelo, firmó con Warner Bros. Records en 2014 y lanzó su álbum debut homónimo en 2017",
                        "/Images/dualipa.PNG"
                        );
                int artista9 = artistacen.New_ ("Harry Styles",
                        "Harry Edward Styles es un cantante, compositor y actor británico. Inició su carrera como cantante en 2010 como integrante de la boy band One Direction, con la que participó en el programa The X Factor y quedó en tercer lugar",
                        "/Images/harry.jpg"
                        );
                Console.WriteLine (" ");
                Console.WriteLine ("Artista " + artista1 + " creado correctamente");
                Console.WriteLine ("Artista " + artista2 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de albumes
                int album1 = albumcen.New_ ("Invitation to Her's", "Segundo album de la banda Her's",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "/Images/invitationto.png", artista1,
                        6.00, 0);

                int album2 = albumcen.New_ ("Plastic Beach", "Tercer album de la banda Gorillaz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rock, "/Images/plasticbeach2.jpg", artista2,
                        7.99, 0);
                int album3 = albumcen.New_ ("Song of Her's", "Primer album de la banda Her's",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "/Images/songof.jpg", artista1,
                        41.43, 0);
                int album4 = albumcen.New_ ("Jazz is for Ordinary People", "Primer EP de Berlioz, donde exploran el genero del Jazz de forma mas profunda",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.jazz, "/Images/jazzisfor.jpg", artista4,
                        2.99, 0);
                int album5 = albumcen.New_ ("Demon Days", "Segundo album de la banda Gorillaz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rock, "/Images/demondays.jpg", artista2,
                        4.99, 0);
                int album6 = albumcen.New_ ("Humanz", "Quinto album de la banda Gorillaz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rock, "/Images/humanz.jpg", artista2,
                        9.99, 0);
                int album7 = albumcen.New_ ("Ramona", "Album hip-hop y rap del artista Kill-Bill: The Rapper",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rap, "/Images/ramona.jpg", artista3,
                        7.99, 0);
                int album8 = albumcen.New_ ("Outer Wilds Original Soundtrack", "Album con la música original del videojuego Outer Wilds",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.bandaSonora, "/Images/outerwilds.jpg", artista5,
                        19.99, 0);
                int album9 = albumcen.New_ ("La Cantera", "La cantera es el primer álbum de Guitarricadelafuente, cuyo lanzamiento se anuncia con un tráiler el 24 de febrero de 2022",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.espanola, "/Images/lacantera.jpg", artista6,
                        14.99, 0); 
                int album10 = albumcen.New_ ("Me Muevo con Dios", "Aclamado disco del famoso rapero canario Cruz Cafune",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rap, "/Images/memuevocon.jpg", artista7,
                        22.54, 0);
                int album11 = albumcen.New_ ("Future Nostalgia", "Future Nostalgia es el segundo álbum de estudio de la cantante británica-kosovar Dua Lipa.​​ Fue lanzado el 27 de marzo de 2020 por el sello discográfico Warner Records",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.pop, "/Images/futurenostalgia.jpg", artista8,
                        13.76, 0);
                int album12 = albumcen.New_ ("Fine Line", "Segundo album de estudio del artista britanico Harry Styles",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.pop, "/Images/fineline.jpg", artista9,
                        15.25, 0);        
                Console.WriteLine (" ");
                Console.WriteLine ("Album " + album1 + " creado correctamente");
                Console.WriteLine ("Album " + album2 + " creado correctamente");
                Console.WriteLine ("Album " + album3 + " creado correctamente");
                Console.WriteLine (" ");

                //Creacion de comunidades
                int comunidad1 = comunidadcen.New_ ("Locos por el Jazz", "/Images/jazz.png", 15);
                int comunidad2 = comunidadcen.New_ ("Rock and Stone", "/Images/rock.png", 47);
                int comunidad3 = comunidadcen.New_ ("Beats", "/Images/rap.jpg", 73);
                int comunidad4 = comunidadcen.New_ ("Las Mejores OST", "/Images/ost.PNG", 73);
                int comunidad5 = comunidadcen.New_ ("Motomamis", "/Images/espanola.jpg", 73);
                int comunidad6 = comunidadcen.New_ ("Club de Fans de Harry Styles", "/Images/pop.jpg", 73);


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
                int comentarioAlb4 = comentarioalbcen.New_ (usuario2, album1,
                        "De los mejores albumes indie de la decada",
                        new DateTime (2023, 11, 08));
                int comentarioAlb5 = comentarioalbcen.New_ (usuario3, album3,
                        "No está mal",
                        new DateTime (2023, 11, 09));
                int comentarioAlb6 = comentarioalbcen.New_ (usuario3, album2,
                        "Es increible",
                        new DateTime (2023, 10, 08));

                //Creacion de comentarios de comunidades
                int comentarioCom1 = comentariocomcen.New_ (usuario1, comunidad1,
                        "Ojalá el jazz renaciese",
                        new DateTime (2023, 11, 07));
                int comentarioCom2 = comentariocomcen.New_ ("alvaro@gmail.com", comunidad2,
                        "Como me gusta el Rock",
                        new DateTime (2023, 11, 07));
                int comentarioCom3 = comentariocomcen.New_ (usuario2, comunidad3,
                        "Me encanta el rap, me activa para pasar el dia",
                        new DateTime (2023, 11, 07));
                int comentarioCom4 = comentariocomcen.New_ (usuario2, comunidad1,
                        "Pues a mi no me termina de gustar",
                        new DateTime (2023, 11, 08));
                int comentarioCom5 = comentariocomcen.New_ (usuario1, comunidad2,
                        "Es de mis generos favoritos",
                        new DateTime (2023, 11, 07));
                int comentarioCom6 = comentariocomcen.New_ (usuario3, comunidad3,
                        "Cruz cafune mi dios",
                        new DateTime (2023, 11, 09));


                //Cracion de pedidos
                int pedido1 = pedidocen.New_ (new DateTime (2023, 11, 09), "Calle del Oro 1", 0,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum.visa,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum.pendiente, usuario1);
                int pedido2 = pedidocen.New_ (new DateTime (2023, 11, 08), "Calle del Viento 12", 0,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum.visa,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum.pendiente, usuario2);
                int pedido3 = pedidocen.New_ (new DateTime (2023, 11, 06), "Calle del Oro 1", 0,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum.visa,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoPedidoEnum.aceptado, usuario1);

                //Creacion de lineas de pedido
                LineaPedidoCP lineaPedidoCP = new LineaPedidoCP (new SessionCPNHibernate ());

                lineaPedidoCP.New_ (21.42, pedido1, album1);
                lineaPedidoCP.New_ (7.99, pedido1, album2);
                lineaPedidoCP.New_ (7.99, pedido2, album2);
                lineaPedidoCP.New_ (41.43, pedido3, album3);

                PedidoEN pedidoEN = pedidocen.GetID (pedido1);
                Console.WriteLine (" ");
                Console.WriteLine ("El total del pedido " + pedidoEN.Id + " es: " + "{0:N2}", pedidoEN.Total);
                Console.WriteLine (" ");

                pedidoEN = pedidocen.GetID (pedido2);
                Console.WriteLine (" ");
                Console.WriteLine ("El total del pedido " + pedidoEN.Id + " es: " + "{0:N2}", pedidoEN.Total);
                Console.WriteLine (" ");

                pedidoEN = pedidocen.GetID (pedido3);
                Console.WriteLine (" ");
                Console.WriteLine ("El total del pedido " + pedidoEN.Id + " es: " + "{0:N2}", pedidoEN.Total);
                Console.WriteLine (" ");

                //Probar CUSTOMS

                //USUARIO
                //Modificamos el nombre del usuario
                usuariocen.ModificarNombre ("alvaro@gmail.com", "Alvaro");
                //Modificamos la imagen del usuario
                usuariocen.ModificarImagen ("alvaro@gmail.com", "/Images/alvaro.jpg");
                /* Esta no funciona, el metodo no cambia correctamente la contraseña. Seguramente por temas de encriptado.
                 * //Modificamos la password e iniciamos sesion
                 * usuariocen.ModificarPass ("alvaro@gmail.com", "1212");
                 * if (usuariocen.Login ("alvaro@gmail.com", "1212") != null) {
                 *      Console.WriteLine ("Usuario loggeado");
                 * }*/

                UsuarioEN usuarioen1 = usuariorepository.GetID (usuario1);

                Console.WriteLine (" ");
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
                artistacen.ModificarImagen (artista1, "/Images/hers.jpg");


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

                // FILTRO PARA COMPROBAR TODOS LOS COMENTARIOS DE UN USUARIO EN LOS ALBUMES
                IList<ComentarioAlbEN> listaCommAlbUsu = comentarioalbcen.GetCommentsAlbumsUsu (usuario3);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los comentarios de ALBUMES del usuario: " + usuario3);

                foreach (ComentarioAlbEN comentario in listaCommAlbUsu) { // recorrer la lista
                        Console.WriteLine ("Comentario: " + comentario.Id + ": " + comentario.Texto);
                }
                Console.WriteLine (" ");

                // FILTRO PARA COMPROBAR TODOS LOS COMENTARIOS DE UN USUARIO EN LOS COMUNIDADES
                IList<ComentarioComEN> listaCommComunidadesUsu = comentariocomcen.GetCommentsComunidadUsu (usuario3);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los comentarios del COMUNIDADES del usuario: " + usuario3);

                foreach (ComentarioComEN comentario in listaCommComunidadesUsu) { // recorrer la lista
                        Console.WriteLine ("Comentario: " + comentario.Id + ": " + comentario.Texto);
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
                IList<ArtistaEN> listaArtistasFavs = artistacen.GetArtistasFavsUsu (usuario1);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los ARTISTAS FAVORITOS de email: " + usuario1);

                foreach (ArtistaEN artista in listaArtistasFavs) { // recorrer la lista
                        Console.WriteLine ("Artista " + artista.Nombre);
                }

                Console.WriteLine (" ");

                // FILTRO ALBUMES DE UN GENERO
                IList<AlbumEN> listaAlbumesDelGenero =
                        albumcen.GetAlbumsDelGenero (ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie);

                Console.WriteLine (" ");
                Console.WriteLine ("Consulta de los AlBUMES que pertenecen al genero musical INDIE");

                foreach (AlbumEN album in listaAlbumesDelGenero) { // recorrer la lista
                        Console.WriteLine ("Album " + album.Nombre);
                }

                Console.WriteLine (" ");




                //Probar CUSTOM TRANSSACTIONS
                Console.WriteLine ("----Customs Transactions----");
                Console.WriteLine (" ");

                AdminCP adminCP = new AdminCP (new SessionCPNHibernate ());

                //Transsaction de baneo permanente
                Console.WriteLine ("Transsaction de Baneo Permanente");
                Console.WriteLine ("Estado usuario anterior: " + usuarioen1.Estado);
                Console.WriteLine (" ");

                adminCP.BaneoPermanente (usuarioen1.Email);
                usuarioen1.Estado = ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoPermanente;

                Console.WriteLine (" ");
                Console.WriteLine ("Estado usuario actual: " + usuarioen1.Estado);
                Console.WriteLine (" ");

                //Transsacion de baneo temporal
                Console.WriteLine ("Transsaction de Baneo Temporal");
                Console.WriteLine ("Estado usuario anterior: " + usuarioen1.Estado);
                Console.WriteLine (" ");

                adminCP.BaneoTemporal (usuarioen1.Email);
                usuarioen1.Estado = ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.baneadoTemporal;

                Console.WriteLine (" ");
                Console.WriteLine ("Estado usuario actual: " + usuarioen1.Estado);
                Console.WriteLine (" ");

                //Transsaction de pagar album
                PedidoCP pedidoCP = new PedidoCP (new SessionCPNHibernate ());

                pedidoCP.PagarPedido (pedidoEN.Id, usuarioen1.Email);
                usuarioen1.Album = new List<AlbumEN>();

                Console.WriteLine (usuarioen1.Album.Count > 0  ? usuarioen1.Album [0].Precio : "Albumes");

                /*PROTECTED REGION END*/

                UsuarioCP cP = new UsuarioCP(new SessionCPNHibernate ());
                /*cP.AddAlbumBuy(album10, usuario2);
                cP.AddAlbumBuy(album2, usuario2);

                albumcen.AnyadirFavorito(album8, new List<string>(){usuario2});
                albumcen.AnyadirFavorito(album7, new List<string>(){usuario2});

                artistacen.AnyadirFavorito(artista4, new List<string>(){usuario2});
                artistacen.AnyadirFavorito(artista3, new List<string>(){usuario2});*/
  
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
