using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Negocios; 

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

            NegocioLogin negocioLogin = new NegocioLogin();

            if (negocioLogin.ValidarUsuario(usuario, contrasena))
            {
                Session["usuario"] = usuario;
                Response.Redirect("~/Administrador/MenuAdministrador.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }

            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }
    }
}