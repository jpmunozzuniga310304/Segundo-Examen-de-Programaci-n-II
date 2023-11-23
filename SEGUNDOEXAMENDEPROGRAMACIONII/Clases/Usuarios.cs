using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

//Segundo Examen de Programación II: Mantenimiento de tres tablas:  Equipos, Usuarios y tecnicos 
//Estudiante: José Pablo Muñoz Zúñiga
//Carrera: Ingeniería Informática
//Materia: Prográmacion II 

namespace SEGUNDOEXAMENDEPROGRAMACIONII.Clases
{
    // En esta parte es toda la programación para hacer funcionar esta clase usuarios
    public class Usuarios
    {
        public int Id { get; set; }
        public string CorreoElectronico { get; set; }

        // En esta parte es un constructor de la clase usuarios para hacer funcionar el boton modificar
        public Usuarios(int id, string correoElectronico)
        {
            Id = id;
            CorreoElectronico = correoElectronico;
        }

        // En esta parte es un constructor de la clase usuarios con datos 
        public Usuarios(string correoelectronico)
        {
            CorreoElectronico = correoelectronico;
        }

        // En esta parte es un constructor de la clase usuarios sin datos 
        public Usuarios()
        {
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase usuarios
        public static int Agregar(string correoelectronico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // En esta parte tiene la funcion para borrar los datos en la clase usuarios
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }


        // En esta parte tiene la funcion para poder consultar los datos en la clase usuarios
        public void Consultar() { }

        // En esta parte tiene la funcion para modificar los datos en la clase usuarios
        public static int Modificar(int codigo, string correoelectronico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICARUSUARIOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // En esta parte tiene la funcion para consultar los datos en la clase equipos
        public static List<Equipos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> Equipos = new List<Equipos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTROEQUIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipos Equipo = new Equipos(reader.GetInt32(0), reader.GetString(1));  // instancia
                            Equipos.Add(Equipo);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Equipos;
        }

        // En esta parte tiene es la segunda programación para que al momento de consultar los datos en la clase equipos funcione
        public static List<Usuarios> ObtenerEquipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> Usuarios = new List<Usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios Usuario = new Usuarios(reader.GetInt32(0), reader.GetString(1));  // instancia
                            Usuarios.Add(Usuario);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Usuarios;
        }
    }

}
