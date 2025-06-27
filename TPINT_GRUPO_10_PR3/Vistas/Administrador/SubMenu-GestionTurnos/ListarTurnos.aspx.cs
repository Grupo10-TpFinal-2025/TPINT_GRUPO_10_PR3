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

        protected void btnFiltarTurno_Click(object sender, EventArgs e)
        {
            //Relleno el dataTable y lo bindeo
            
            DataTable tabla = turno.getTablaPorCodigoTurno(Convert.ToInt32(txtListarTurno.Text.Trim()));
            gvTablaTurnos.DataSource = tabla;
            gvTablaTurnos.DataBind();

            //Si la tabla tiene 0 filas pongo un mensaje diciendo que no se pudo encontrar nada
            if (tabla.Rows.Count <= 0)
            {
                lblMensaje.Text = "No se ha encontrado ninguna sucursal " + txtListarTurno.Text.Trim() + ".";
            }
            else
            {
                lblMensaje.Text = "";
            }

            //Limpio el txt
            txtListarTurno.Text = "";
            
        }

        //Limpio filtros
        protected void btnLimpiarFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            //Cargo la gv normal
            cargarGV();

            //Limpio el txt
            txtListarTurno.Text = "";
        }

        //Evento click filtro avanzado
        protected void btnAplicarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            //Me fijo si hay algun campo seleccionado
            if(txtFiltroFecha.Text == string.Empty || txtFiltroDni.Text == string.Empty)
            {
                lblResultadoFiltroAvanzado.Text = "Se deben ingresar campos para poder usar los filtros avanzados.";
            }
        }
    }
}