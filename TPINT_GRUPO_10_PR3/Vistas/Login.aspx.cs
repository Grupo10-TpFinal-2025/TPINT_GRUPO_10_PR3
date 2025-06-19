using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            AccesoDatos acceso = new AccesoDatos();

            string consulta = "SELECT * FROM UsuarioAdministrador WHERE Nombre_UA = @usuario AND Contraseña_UA = @contrasena AND Estado_UA = 1";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            DataTable tabla = acceso.ObtenerTablaFiltrada("UsuarioAdministrador", comando);

            if (tabla.Rows.Count > 0)
            {
                Session["usuario"] = usuario;
                Response.Redirect("~/Administrador/MenuAdministrador.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
            txtUsuario.Text = String.Empty;
            txtContraseña.Text = String.Empty;

        }
    }
}