using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
	public partial class ModificacionDisponibilidad : System.Web.UI.Page
	{
        //Variable del form
        NegocioDisponibilidad disponibilidad = new NegocioDisponibilidad();

        //Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifico que se haya iniciado como admin
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            //Postback
            if (!IsPostBack)
            {
                //Marco el usuario como admin
                lblUsuarioAdministrador.Text = "Administrador";

                //Cargo la tabla
                cargarGV();
            }
        }

        
        //Funcion cargar gv
        void cargarGV()
        {
            DataTable tabla = disponibilidad.ObtenerTablaDisponibilidad();
            gvModificacionDisponibilidad.DataSource = tabla;
            gvModificacionDisponibilidad.DataBind();
        }

    }
}