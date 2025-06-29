using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
	public partial class ListarDisponibilidad : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarDisponibilidades();
            }
        }


        protected void btnMenuFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            if (btnMenuFiltrosAvanzados.Text == "Aplicar filtros avanzados")
            {
                pnlFiltrosAvanzados.Visible = true;
                btnMenuFiltrosAvanzados.Text = "Ocultar filtros avanzados";
            }
            else
            {
                pnlFiltrosAvanzados.Visible = false;
                btnMenuFiltrosAvanzados.Text = "Aplicar filtros avanzados";
            }
        }

        private void CargarDisponibilidades()
        {
            NegocioDisponibilidad negocio = new NegocioDisponibilidad();
            lvListaroDisponibilidadM.DataSource = negocio.ObtenerTablaDisponibilidades();
        }
    }
}