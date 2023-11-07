
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
                ComentarioRepository comentariorepository = new ComentarioRepository ();
                ComentarioCEN comentariocen = new ComentarioCEN (comentariorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                LineaPedidoRepository lineapedidorepository = new LineaPedidoRepository ();
                LineaPedidoCEN lineapedidocen = new LineaPedidoCEN (lineapedidorepository);
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                //Cracion de INSTANCIAS
                //Creacion de usuarios
                string usuario1 = usuariocen.New_ ("ablarb", "0000", "alvaro@gmail.com", new DateTime (2000, 10, 23),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.masculino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "fallo");
                string usuario2 = usuariocen.New_ ("Sara", "1313", "sara@gmail.com", new DateTime (1998, 06, 10),
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.femenino,
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "perfil2.jpg");
                Console.WriteLine ("Usuario " + usuario1 + " creado correctamente");
                Console.WriteLine ("Usuario " + usuario2 + " creado correctamente");

                //Creacion de artistas
                int artista1 = artistacen.New_ ("Her's",
                        "Her's fue una banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros",
                        "fallo.jpg"
                        );
                int artista2 = artistacen.New_ ("Gorillaz",
                        "Banda virtual inglesa creada en 1998 por Damon Albarn y Jamie Hewlett. La banda está compuesta por cuatro miembros ficticios",
                        "artista2.jpg"
                        );
                Console.WriteLine ("Artista " + artista1 + " creado correctamente");
                Console.WriteLine ("Artista " + artista2 + " creado correctamente");

                //Creacion de artistas
                int album1 = albumcen.New_ ("Invitation to Her's", "Segundo album de la banda Her's",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "portada1.jpg", artista1,
                        6.00);
                int album2 = albumcen.New_ ("Plastic Beach", "Tercer album de la banda Gorillaz",
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.rock, "portada2.jpg", artista2,
                        7.99);
                Console.WriteLine ("Album " + album1 + " creado correctamente");
                Console.WriteLine ("Album " + album2 + " creado correctamente");


                //Probar CUSTOMS
                //USUARIO

                //Modificamos el estado a "2", equivalente a "baneado temporal"
                usuariocen.ModificarEstado ("alvaro@gmail.com", 2);

                //Modificamos el nombre del usuario
                usuariocen.ModificarNombre ("alvaro@gmail.com", "Alvaro");

                //Modificamos la imagen del usuario
                usuariocen.ModificarImagen ("alvaro@gmail.com", "perfil1.jpg");


                //ALBUM

                //Modificamos el precio del album
                albumcen.ModificarPrecio (album1, 21.42);


                //ARTISTA

                //Modificamos la descripcion del artista
                artistacen.ModificarDescripcion (artista1, "Banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros");

                //Modificamos la imagen del artista
                artistacen.ModificarImagen (artista1, "artista1.jpg");

                /* Esto no funciona, el metodo no cambia correctamente la contraseña. Seguramente por temas de encriptado.
                 * //Modificamos la password e iniciamos sesion
                 * usuariocen.ModificarPass ("alvaro@gmail.com", "1212");
                 * if (usuariocen.Login ("alvaro@gmail.com", "1212") != null) {
                 *      Console.WriteLine ("Usuario loggeado");
                 * }*/


                //Probar FILTERS

                //Filtro de usuarios con un estado en especifico
                IList<UsuarioEN> listaUsuariosEstado = 
                usuariocen.GetUsuariosEstado(ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal);

                Console.WriteLine ("Consulta de los usuarios con determinado estado ");
                

                foreach (UsuarioEN usuario in listaUsuariosEstado) { // recorrer la lista
                        Console.WriteLine ("El usuario: " + usuario.Email+" . De nombre: "+usuario.Nombre);
                }



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
