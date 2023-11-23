using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//Segundo Examen de Programación II: Mantenimiento de tres tablas:  Equipos, Usuarios y tecnicos 
//Estudiante: José Pablo Muñoz Zúñiga
//Carrera: Ingeniería Informática
//Materia: Prográmacion II 

namespace SEGUNDOEXAMENDEPROGRAMACIONII.Clases
{
    public class DBConn
    {
        // En esta parte sirve para extraer los datos del sql server management studio al visual studio en c#
        public static SqlConnection obtenerConexion()
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            return conexion;
        }
    }
}