using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas.Medico
{
    public partial class CambioDeTurno : System.Web.UI.Page
    {
        NegocioTurno negocioTurno;
        Turno turno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["legajo"]  == null)
            {
                lblMensaje.Text = "No se ha logrado encontrar el registro de legajo médico. Por favor, inicie sesión nuevamente.";
            }

            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"].ToString();
            }
        }

        public void CargarTurnosMedico()
        {
            negocioTurno = new NegocioTurno();
            gvActualizacionTurnos.DataSource = negocioTurno.getTurnosXMedico(Convert.ToInt32(Session["legajo"]));
            gvActualizacionTurnos.DataBind();
        }

        protected void gvActualizacionTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvActualizacionTurnos.EditIndex = e.NewEditIndex;
            CargarTurnosMedico();

        }

        protected void gvActualizacionTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvActualizacionTurnos.EditIndex = -1;
            CargarTurnosMedico();
        }

        protected void gvActualizacionTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActualizacionTurnos.EditIndex = -1;
            gvActualizacionTurnos.PageIndex = e.NewPageIndex;
            CargarTurnosMedico();

        }

        protected void gvActualizacionTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            negocioTurno = new NegocioTurno();
            turno = new Turno();

            turno.CodTurno = Convert.ToInt32(((Label)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("lbl_et_IDTurno")).Text);
            turno.Fecha = DateTime.Parse(((Label)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("lbl_et_Fecha")).Text);
            turno.LegajoPaciente = Convert.ToInt32(((Label)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("lbl_et_LegajoPaciente")).Text);
            if (((CheckBoxList)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("cbl_et_Asistencia")).SelectedValue != null)
            {

                turno.Asistencia = ((CheckBoxList)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("cbl_et_Asistencia")).SelectedValue;
            }
            else
            {
                turno.Asistencia = "NULL";
            }
            turno.Descripcion = ((TextBox)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("txt_et_Descripcion")).Text;

            int resultado = negocioTurno.ModificarTurno(turno);
            if (resultado > 0)
            {
                lblMensaje.Text = "Turno actualizado correctamente.";
                gvActualizacionTurnos.EditIndex = -1;
                CargarTurnosMedico();
            }
            else
            {
                lblMensaje.Text = "Error al actualizar el turno. Verifique los datos ingresados.";
            }
        }
    }
}