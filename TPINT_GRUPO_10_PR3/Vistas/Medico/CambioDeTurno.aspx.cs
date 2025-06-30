using System;
using System.Collections.Generic;
using System.Data;
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
                CargarTurnosMedico();
            }
        }

        public void CargarTurnosMedico()
        {
            negocioTurno = new NegocioTurno();
            DataTable TurnosMedico = negocioTurno.getTurnosXMedico(Convert.ToInt32(Session["legajo"]));
            gvActualizacionTurnos.DataSource = TurnosMedico;
            gvActualizacionTurnos.DataBind();
            if(TurnosMedico.Rows.Count <= 0)
            {
                lblMensaje.Text = "No se encontraron registros de turnos vigentes.";
            }

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
            turno.Asistencia = ((RadioButtonList)gvActualizacionTurnos.Rows[e.RowIndex].FindControl("rbl_et_Asistencia")).SelectedValue;
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

        protected void gvActualizacionTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            turno = new Turno();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    Label lblFecha = (Label)e.Row.FindControl("lbl_it_Fecha");
                    DateTime fechaTurno = Convert.ToDateTime(lblFecha.Text);


                    if (fechaTurno < DateTime.Now)
                    {
                        LinkButton btnEditar = (LinkButton)e.Row.FindControl("lbtn_it_Editar");
                        btnEditar.Enabled = true;
                    }
                    else
                    {
                        LinkButton btnEditar = (LinkButton)e.Row.FindControl("lbtn_it_Editar");
                        btnEditar.Enabled = false;
                    }

                    Label lblAsistencia = (Label)e.Row.FindControl("lbl_it_Asistencia");

                    if (lblAsistencia.Text.Trim() != null)
                    {
                        if (lblAsistencia.Text.ToLower() == "false")
                        {
                            lblAsistencia.Text = "Ausente";
                        }
                        else if (lblAsistencia.Text.ToLower() == "true")
                        {
                            lblAsistencia.Text = "Presente";
                        }
                        else
                        {
                            lblAsistencia.Text = "Sin registrar";
                        }
                    }
                    else
                    {
                        lblAsistencia.Text = "Sin registrar";

                    }

                    Label lblDescripcion = (Label)e.Row.FindControl("lbl_it_Descripcion");

                    if (lblDescripcion == null)
                    {
                        if (string.IsNullOrEmpty(lblDescripcion.Text))
                        {
                            lblDescripcion.Text = "----------";
                        }
                    }
                }
                else
                {
                    RadioButtonList cblAsistencia = (RadioButtonList)e.Row.FindControl("rbl_et_Asistencia");
                    string asistencia = DataBinder.Eval(e.Row.DataItem, "Asistencia").ToString();

                    if (!string.IsNullOrEmpty(asistencia))
                    {
                        if (asistencia.ToLower() == "true")
                        {
                            cblAsistencia.Items[2].Selected = true;
                        }
                        else if (asistencia.ToLower() == "false")
                        {
                            cblAsistencia.Items[1].Selected = true; 
                        }
                    }
                    else
                    {
                        cblAsistencia.Items[0].Selected = true; 
                    }

                }
            }
        }
    }
}