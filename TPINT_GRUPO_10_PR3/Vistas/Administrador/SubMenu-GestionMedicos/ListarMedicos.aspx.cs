using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
	public partial class ListarMedicos : System.Web.UI.Page
	{
        private readonly Negocios.NegocioMedico negocioMedico = new Negocios.NegocioMedico();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";

                CargarTablaMedicos();
            }
        }

        protected void btnMenuFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            if (btnMenuFiltrosAvanzados.Text == "Aplicar Filtros Avanzados")
            {
                pnlFiltrosAvanzados.Visible = true;
                btnMenuFiltrosAvanzados.Text = "Ocultar Filtros Avanzados";
            }
            else
            {
                pnlFiltrosAvanzados.Visible = false;
                btnMenuFiltrosAvanzados.Text = "Aplicar Filtros Avanzados";
            }
        }

        private void CargarTablaMedicos()
        {
            gvListaMedicos.DataSource = negocioMedico.getTablaMedicos();
            gvListaMedicos.DataBind();
        }

        protected void gvListaMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaMedicos.PageIndex = e.NewPageIndex;
            CargarTablaMedicos();
        }
    }
}