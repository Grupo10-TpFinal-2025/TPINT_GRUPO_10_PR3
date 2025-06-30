using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
	public partial class ListarDisponibilidad : System.Web.UI.Page
	{
        NegocioDisponibilidad negocioDisponibilidad = new NegocioDisponibilidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarEspecialidades();
                CargarDisponibilidad();
                CargarDia();
            }
        }

        private void CargarEspecialidades()
        {
            NegocioEspecialidad negocio = new NegocioEspecialidad();
            gvEspecialidades.DataSource = negocio.ObtenerEspecialidades();
            gvEspecialidades.DataBind();
        }

        private void CargarDia()
        {
            NegocioDia negocio = new NegocioDia();
            DataTable tablaDias = negocio.ObtenerTablaDia();

            DataRow filaTodos = tablaDias.NewRow();
            filaTodos["Descripcion_DI"] = "Todos";
            filaTodos["NumDia_DI"] = 0; // un valor especial que no venga de la BD

            tablaDias.Rows.InsertAt(filaTodos, 0); // lo agrega en la posición 0 (principio)

            gvDias.DataSource = tablaDias;
            gvDias.DataBind();
        }

        private void CargarDisponibilidad()
        {
            NegocioDisponibilidad negocio = new NegocioDisponibilidad();
            gvDisponibilidades.DataSource = negocio.ObtenerTablaDisponibilidad(0, 0);
            gvDisponibilidades.DataBind();
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

        protected void btnEspecialidad_Command(object sender, CommandEventArgs e)
        {
            int codEspecialidad = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "FiltroEspecialidad")
            {
                Session["EspecialidadSeleccionada"] = codEspecialidad;
                                
                gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0);
                gvDisponibilidades.DataBind();
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            Session["EspecialidadSeleccionada"] = null;           

            gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0);
            gvDisponibilidades.DataBind();
        }

        protected void gvDias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDia_Command(object sender, CommandEventArgs e)
        {
            int diaSeleccionado  = Convert.ToInt32(e.CommandArgument);
           

            if(Session["EspecialidadSeleccionada"] != null)
            {
                int codEspecialidad = (int)Session["EspecialidadSeleccionada"];

                if (diaSeleccionado > 0)
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, diaSeleccionado);
                }
               else
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0);
                }
                                
            }

            else
            {
                if(diaSeleccionado > 0)
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, diaSeleccionado);
                }
                else
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0);
                }
            }

            gvDisponibilidades.DataBind();
        }
    }
}