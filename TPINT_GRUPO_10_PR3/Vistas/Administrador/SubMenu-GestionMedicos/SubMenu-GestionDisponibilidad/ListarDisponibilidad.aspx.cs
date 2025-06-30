using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            filaTodos["NumDia_DI"] = 0; // Value = '0'

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

        private void ResetearColoresBotonesEspecialidad()
        {
            // Especialidades
            foreach (GridViewRow fila in gvEspecialidades.Rows)
            {
                Button btn = (Button)fila.FindControl("btnEspecialidad");
                if (btn != null)
                {
                    btn.BackColor = System.Drawing.Color.Empty;
                }
            }
        }
        private void ResetearColoresBotonesDia() 
        { 
            foreach (GridViewRow fila in gvDias.Rows)
            {
                Button btn = (Button)fila.FindControl("btnDia");
                if (btn != null)
                {
                    btn.BackColor = System.Drawing.Color.Empty;
                }
            }
        }

        protected void btnEspecialidad_Command(object sender, CommandEventArgs e)
        {
            ResetearColoresBotonesDia();

            int codEspecialidad = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "FiltroEspecialidad")
            {
                ResetearColoresBotonesEspecialidad();

                Session["EspecialidadSeleccionada"] = codEspecialidad;

                Button btnEspecialidadSeleccionada = (Button)sender;
                btnEspecialidadSeleccionada.BackColor = Color.DarkGray;
                                
                gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0);
                gvDisponibilidades.DataBind();
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ResetearColoresBotonesEspecialidad();
            ResetearColoresBotonesDia();

            Session["EspecialidadSeleccionada"] = null;           


            gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0);
            gvDisponibilidades.DataBind();


        }


        protected void btnDia_Command(object sender, CommandEventArgs e)
        {
            ResetearColoresBotonesDia();

            int diaSeleccionado  = Convert.ToInt32(e.CommandArgument);
            
            Button btnDiaSeleccionado = (Button)sender;
            btnDiaSeleccionado.BackColor = Color.DarkGray;

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