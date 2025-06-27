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
    public partial class ListarTurnos : System.Web.UI.Page
    {
        //Variable del form
        NegocioTurno turno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Codigo para que anden las validaciones
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            //Si se ingreso por error que devuelva a login
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            //Postback
            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                cargarGV();
            }
        }

        //No se
        protected void txtListarTurno_TextChanged(object sender, EventArgs e)
        {

        }

        //Filtro avanzado
        protected void btnAplicarFiltroAvanzado0_Click(object sender, EventArgs e)
        {
            if(panelListarTurnos.Visible == false)
            {
                panelListarTurnos.Visible = true;
                btnMostrarFiltrosAvanzado0.Text = "Ocultar Filtros Avanzados";
            }

            else
            {
                panelListarTurnos.Visible = false;
                btnMostrarFiltrosAvanzado0.Text = "Aplicar Filtros Avanzados";
            }
        }

        //Funcion que carga la gv con parametros default
        void cargarGV()
        {
            DataTable tabla = turno.getTabla();
            gvTablaTurnos.DataSource = tabla;
            gvTablaTurnos.DataBind();
        }

        //Evento de cambio de pagina
        protected void gvTablaTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTablaTurnos.PageIndex = e.NewPageIndex;
            cargarGV();
        }
    }
}