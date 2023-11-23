using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Segundo Examen de Programación II: Mantenimiento de tres tablas:  Equipos, Usuarios y tecnicos 
//Estudiante: José Pablo Muñoz Zúñiga
//Carrera: Ingeniería Informática
//Materia: Prográmacion II 

namespace SEGUNDOEXAMENDEPROGRAMACIONII
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        //En esta parte es para cargar la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        //En esta parte es para transferir los datos del sql management studio al visual studio en c#
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt; // se carga la tabla
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        //En esta parte son las alertas cuya funcion es cuando el usuario digita un numero para saber si lo ingreso correctamente o no
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        //En esta parte es para que el boton agregar funcione correctamente

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Agregar(tespecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Especialidad ingresada con exito");
            }
            else
            {
                alertas("Error al ingresar la especialidad");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Borrar(int.Parse(tcodigo.Text)) > 0)
            {
                LlenarGrid(); // actualizar el grid
                alertas("Especialidad borrada con exito");
            }
            else
            {
                alertas("Error al borrar la especialidad");
            }
        }

        //En esta parte es para que el boton de modificar funcione correctamente
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Modificar(int.Parse(tcodigo.Text), tespecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Especialidad modificada con exito");
            }
            else
            {
                alertas("Error al modificar la especialidad");
            }
        }

        //En esta parte es para que el boton de consultar funcione correctamente
        protected void Button2_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        //En esta parte es para que la descripcion funcione correctamente
        protected void tdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        //En esta parte es para que el codigo funcione correctamente
        protected void tcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        //En esta parte es para que la fecha funcione correctamente
        protected void tfecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}