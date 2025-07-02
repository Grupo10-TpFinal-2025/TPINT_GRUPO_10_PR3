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

        private readonly NegocioDisponibilidad negocioDisponibilidad = new NegocioDisponibilidad();
        private readonly NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        private readonly NegocioDia negocioDia = new NegocioDia();


        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
            gvEspecialidades.DataSource = negocioEspecialidad.ObtenerEspecialidades();
            gvEspecialidades.DataBind();
        }

        private void CargarDia()
        {
            DataTable tablaDias = negocioDia.ObtenerTablaDia();

            DataRow filaTodos = tablaDias.NewRow();
            filaTodos["Descripcion_DI"] = "Todos";
            filaTodos["NumDia_DI"] = 0; // Value = '0'

            tablaDias.Rows.InsertAt(filaTodos, 0); // lo agrega en la posición 0 (principio)

            gvDias.DataSource = tablaDias;
            gvDias.DataBind();
        }

        private void CargarDisponibilidad()
        {
            Session["TablaDisponibilidad"] = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0, 0);
            gvDisponibilidades.DataSource = (DataTable)Session["TablaDisponibilidad"];

            gvDisponibilidades.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ResetearColoresBotonesEspecialidad();
            ResetearColoresBotonesDia();
            LimpiarFiltros();

            Session["EspecialidadSeleccionada"] = null;

            CargarDisponibilidad();

            VerificarNumeroRegistros();
        }

        protected void btnEspecialidad_Command(object sender, CommandEventArgs e)
        {
            ResetearColoresBotonesDia();
            LimpiarFiltros();

            int codEspecialidad = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "FiltroEspecialidad")
            {
                ResetearColoresBotonesEspecialidad();

                Session["EspecialidadSeleccionada"] = codEspecialidad;

                Button btnEspecialidadSeleccionada = (Button)sender;
                btnEspecialidadSeleccionada.BackColor = Color.DarkGray;

                Session["TablaDisponibilidad"] = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0, 0);
                gvDisponibilidades.DataSource = (DataTable)Session["TablaDisponibilidad"];
                gvDisponibilidades.DataBind();

                VerificarNumeroRegistros();
            }
        }

        protected void btnDia_Command(object sender, CommandEventArgs e)
        {
            ResetearColoresBotonesDia();
            LimpiarFiltros();

            int diaSeleccionado  = Convert.ToInt32(e.CommandArgument);

            DataTable tablaDisponibilidad;

            Button btnDiaSeleccionado = (Button)sender;
            btnDiaSeleccionado.BackColor = Color.DarkGray;

            if(Session["EspecialidadSeleccionada"] != null)
            {
                int codEspecialidad = (int)Session["EspecialidadSeleccionada"];


                tablaDisponibilidad = (diaSeleccionado > 0)
                ? negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, diaSeleccionado, 0)
                : negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0, 0);
                
                                

                if (diaSeleccionado > 0)
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, diaSeleccionado, 0);
                }
                else
                {
                    gvDisponibilidades.DataSource = negocioDisponibilidad.ObtenerTablaDisponibilidad(codEspecialidad, 0, 0);
                }              
            }
            else
            {
                tablaDisponibilidad = (diaSeleccionado > 0)                
                ? negocioDisponibilidad.ObtenerTablaDisponibilidad(0, diaSeleccionado, 0)                                                
                : negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0, 0);
                
            }

            Session["TablaDisponibilidad"] = tablaDisponibilidad;

            gvDisponibilidades.DataSource = tablaDisponibilidad;
            gvDisponibilidades.DataBind();

            VerificarNumeroRegistros();            

            VerificarNumeroRegistros();
        }

        protected void btnFiltrarMedicoLegajo_Click(object sender, EventArgs e)
        {
            ResetearColoresBotonesDia();
            ResetearColoresBotonesEspecialidad();


            int legajoMedico = Convert.ToInt32(txtFiltroLegajoMedico.Text);

            Session["TablaDisponibilidad"] = negocioDisponibilidad.ObtenerTablaDisponibilidad(0, 0, legajoMedico);

            gvDisponibilidades.DataSource = (DataTable)Session["TablaDisponibilidad"];
            gvDisponibilidades.DataBind();

            if(gvDisponibilidades.Rows.Count == 0)
            {
                lblLegajoNoEncontrado.Visible = true;
            }
            else
            {
                lblLegajoNoEncontrado.Visible = false;
            }
                           
            LimpiarFiltros();                        
        }
        

        protected void btnAplicarFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            
            ResetearColoresBotonesDia();
            ResetearColoresBotonesEspecialidad();

            string cadenaFiltroAvanzado = ObtenerCadenaFiltroAvanzado();

            if(cadenaFiltroAvanzado == null)
            {
                lblSinFiltroAvanzado.Visible = true;
                return;
            }

            else
            {
                Session["TablaDisponibilidad"] = negocioDisponibilidad.ObtenerTablaDisponibilidadFiltroAvanzado(cadenaFiltroAvanzado);
                gvDisponibilidades.DataSource = (DataTable)Session["TablaDisponibilidad"];
                gvDisponibilidades.DataBind();
            }
            
            lblSinFiltroAvanzado.Visible = false;
            LimpiarFiltros();
        }

 

        protected void gvDisponibilidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisponibilidades.PageIndex = e.NewPageIndex;

            if (Session["TablaDisponibilidad"] != null)
            {
                gvDisponibilidades.DataSource = (DataTable)Session["TablaDisponibilidad"];
                gvDisponibilidades.DataBind();
            }
        }

        private string ObtenerCadenaFiltroAvanzado()
        {
            string cadena = null;

            string parametroRangoHorario = ddlOperatorsRangoHorario.SelectedValue;
            string parametroEspecialidad = ddlOperatorsEspecialidad.SelectedValue;

            string horario = ddlSeleccionarHorario.SelectedValue;
            string especialidad = txtEspecialidad.Text;

            

            if (horario != "0")
            {
                cadena = " WHERE ";

                switch (parametroRangoHorario)
                {
                    case "a partir de":
                        cadena += $"HorarioInicio_DIS >= '{horario}'";
                        break;

                    default:
                        cadena += $"HorarioFin_DIS < '{horario}'";
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                if(horario != "0")
                {
                    cadena += " AND ";
                }
                else
                {
                    cadena = " WHERE ";
                }

                switch (parametroEspecialidad)
                {
                    case "contiene":
                        cadena += $"E.Descripcion_ES LIKE '%{especialidad}%'";
                        break;
                    case "empieza con":
                        cadena += $"E.Descripcion_ES LIKE '{especialidad}%'";
                        break;
                    default:
                        cadena += $"E.Descripcion_ES LIKE '%{especialidad}'";
                        break;
                }
            }

            return cadena;
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

        private void LimpiarFiltros()
        {
            txtFiltroLegajoMedico.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;

        }

        private void VerificarNumeroRegistros()
        {
            if (gvDisponibilidades.Rows.Count == 0)
            {
                lblSinRegistros.Visible = true;
            }
            else
            {
                lblSinRegistros.Visible = false;
            }
        }


        protected void btnLimpiarFiltrosMedicos_Click(object sender, EventArgs e)
        {
            ResetearColoresBotonesDia();
            ResetearColoresBotonesEspecialidad();

            ddlOperatorsRangoHorario.SelectedIndex = 0;
            ddlOperatorsEspecialidad.SelectedIndex = 0;
            ddlSeleccionarHorario.SelectedIndex = 0;
            txtEspecialidad.Text = string.Empty;
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
    }
}