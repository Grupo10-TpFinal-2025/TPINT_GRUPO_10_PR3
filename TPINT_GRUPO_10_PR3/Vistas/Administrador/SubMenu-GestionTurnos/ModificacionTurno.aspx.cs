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
        private readonly NegocioTurno negocioTurno = new NegocioTurno();

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
                gvModificarTurnos.RowDataBound += gvModificarTurnos_RowDataBound;
            }
        }

        private void cargarGV()
        {
            gvModificarTurnos.DataSource = negocioTurno.getTabla();
            gvModificarTurnos.DataBind();
        }

        protected void gvModificarTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModificarTurnos.EditIndex = -1;
            gvModificarTurnos.PageIndex = e.NewPageIndex;
            cargarGV();
        }

        protected void gvModificarTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificarTurnos.EditIndex = -1; // Salir de modo edición
            cargarGV(); // Recargar la tabla sin cambios
        }

        protected void gvModificarTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificarTurnos.EditIndex = e.NewEditIndex;
            cargarGV(); // Vuelve a cargar el GridView mostrando los controles editables en esa fila
        }

        protected void gvModificarTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow fila = gvModificarTurnos.Rows[e.RowIndex];

                // Obtener el ID del turno (clave primaria)
                int idConsulta = Convert.ToInt32(gvModificarTurnos.DataKeys[e.RowIndex].Value);

                // Obtener el CheckBox de Pendiente
                CheckBox chkPendiente = fila.FindControl("chk_eit_Pendiente") as CheckBox;
                int pendiente = (chkPendiente != null && chkPendiente.Checked) ? 1 : 0;

                // Obtener el CheckBox de Asistencia
                CheckBox chkAsistencia = fila.FindControl("chk_eit_Asistencia") as CheckBox;
                string asistencia = (chkAsistencia != null && chkAsistencia.Checked) ? "1" : "0";

                // Traer la descripción actual (ya que la SP la requiere)
                Label lblDescripcion = fila.FindControl("lbl_it_Descripcion") as Label;
                string descripcion = lblDescripcion != null ? lblDescripcion.Text.Trim() : "";

                // Traer el estado actual (ya que la SP lo requiere)
                CheckBox chkEstado = fila.FindControl("chk_it_Estado") as CheckBox;
                bool estado = chkEstado != null && chkEstado.Checked;

                // Traer la fecha actual (temporal) porque la SP la requiere
                DateTime fecha = DateTime.Now;

                // Crear el objeto Turno
                Turno turnoModificado = new Turno
                {
                    CodTurno = idConsulta,
                    Fecha = fecha,
                    Pendiente = pendiente,
                    Asistencia = asistencia,
                    Descripcion = descripcion,
                    Estado = estado
                };

                // Llamar a NegocioTurno para actualizar en la BD
                int filasAfectadas = negocioTurno.ModificarTurno(turnoModificado);

                if (filasAfectadas > 0)
                {
                    lblModificacionMensaje.ForeColor = System.Drawing.Color.Green;
                    lblModificacionMensaje.Text = "Modificación exitosa.";
                }
                else
                {
                    lblModificacionMensaje.ForeColor= System.Drawing.Color.Red;
                    lblModificacionMensaje.Text = "No se realizó ninguna modificación.";
                }

                gvModificarTurnos.EditIndex = -1;
                cargarGV();
            }
            catch (Exception ex)
            {
                lblModificacionMensaje.ForeColor = System.Drawing.Color.Red;
                lblModificacionMensaje.Text = "❌ Error: " + ex.Message;
            }
        }

        protected void gvModificarTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Nos aseguramos de que es una fila de datos
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Verificamos si la fila está en modo de edición
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //Encontrar el control dentro de la fila
                    CheckBox chkPendiente = e.Row.FindControl("chk_eit_Pendiente") as CheckBox;
                    CheckBox chkAsistencia = e.Row.FindControl("chk_eit_Asistencia") as CheckBox;

                    if (chkPendiente != null && chkAsistencia != null)
                    {
                        chkPendiente.Attributes["onclick"] = $"toggleExclusive('{chkPendiente.ClientID}', '{chkAsistencia.ClientID}', 'pendiente');";
                        chkAsistencia.Attributes["onclick"] = $"toggleExclusive('{chkPendiente.ClientID}', '{chkAsistencia.ClientID}', 'asistencia');";
                    }
                }
            }
        }
    }
}
