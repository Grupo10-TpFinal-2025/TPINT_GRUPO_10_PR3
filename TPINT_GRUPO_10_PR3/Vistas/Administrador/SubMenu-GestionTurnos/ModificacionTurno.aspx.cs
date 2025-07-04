using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionTurnos
{
    
	public partial class ModificacionTurno : System.Web.UI.Page
	{
        NegocioTurno turno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                cargarGV();
            }
        }

        void cargarGV()
        {
            DataTable tabla = turno.getTabla();
            gvModificarTurnos.DataSource = tabla;
            Session["TablaFiltrada"] = tabla;
            gvModificarTurnos.DataBind();
        }
    }
}