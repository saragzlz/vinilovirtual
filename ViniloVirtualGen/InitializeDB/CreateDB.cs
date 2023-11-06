
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

                //Creacion de usuarios
                string usuario1 = usuariocen.New_("Alvaro", "1212", "alvaro@gmail.com",new DateTime(2000, 10, 23),
                 ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.masculino,
                  ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "perfil.jpg");
                string usuario2 = usuariocen.New_("Sara", "1313", "sara@gmail.com",new DateTime(1998, 01, 01),
                 ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum.femenino,
                  ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal, "perfil2.jpg");
                Console.WriteLine("Usuario "+usuario1+" creado correctamente");
                Console.WriteLine("Usuario "+usuario2+" creado correctamente");

                if (usuariocen.Login("alvaro@gmail.com", "1212") != null)
                {
                        Console.WriteLine("Usuario loggeado");
                }

                //Creacion de artistas
                int artista1 = artistacen.New_("Her's", 
                "Banda británica de rock de Liverpool, Inglaterra, compuesta por Stephen Fitzpatrick en voz y guitarra y Audun Laading en bajo y coros",
                "artista1.jpg"
                );
                Console.WriteLine("Artista "+artista1+" creado correctamente");
                

                //Creacion de artistas
                int album1 = albumcen.New_("Invitation to Her's", "Segundo album de la banda Her's",
                 ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroMusicalEnum.indie, "portada1.jpg", artista1);
                Console.WriteLine("Album "+album1+" creado correctamente");


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
