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
        NegocioTurno turno = new NegocioTurno();

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
            }
        }

        void cargarGV()
        {
            DataTable tabla = turno.getTabla();
            gvModificarTurnos.DataSource = tabla;
            Session["TablaFiltrada"] = tabla;
            gvModificarTurnos.DataBind();
        }

        protected void gvModificarTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
                gvModificarTurnos.EditIndex = e.NewEditIndex;
                cargarGV(); // Vuelve a cargar el GridView mostrando los controles editables en esa fila
        }

        protected void gvModificarTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {           
                gvModificarTurnos.EditIndex = -1; // Salir de modo edición
                cargarGV(); // Recargar la tabla sin cambios
        }

        protected void gvModificarTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow fila = gvModificarTurnos.Rows[e.RowIndex];

                // Obtener el ID del turno (clave primaria)
                int idConsulta = Convert.ToInt32(gvModificarTurnos.DataKeys[e.RowIndex].Value);

                // Obtener controles de edición
                CheckBox chkPendiente = fila.FindControl("chk_eit_Pendiente") as CheckBox;
                int pendiente = (chkPendiente != null && chkPendiente.Checked) ? 1 : 0;

                CheckBox chkAsistencia = fila.FindControl("chk_eit_Asistencia") as CheckBox;
                // Pasamos "1" o "0" como string para usar en el SP
                string asistencia = (chkAsistencia != null && chkAsistencia.Checked) ? "1" : "0";

                CheckBox chkEstado = fila.FindControl("chk_eit_Estado") as CheckBox;
                bool estado = chkEstado != null && chkEstado.Checked;

                TextBox txtDescripcion = fila.FindControl("txt_eit_Descripcion") as TextBox;
                string descripcion = txtDescripcion != null ? txtDescripcion.Text.Trim() : "";

                // Traer la fecha actual de la base o usar DateTime.Now temporalmente
                DateTime fecha = DateTime.Now;

                // Crear objeto Turno para enviar al SP
                Turno turnoModificado = new Turno
                {
                    CodTurno = idConsulta,
                    Fecha = fecha,
                    Pendiente = pendiente,
                    Asistencia = asistencia, // "1" o "0"
                    Descripcion = descripcion,
                    Estado = estado // bool
                };

                // Ejecutar actualización en la base
                int resultado = turno.ModificarTurno(turnoModificado);

                if (resultado > 0)
                {
                    lblModificacionMensaje.Text = " Turno actualizado correctamente en la base de datos.";
                }
                else
                {
                    lblModificacionMensaje.Text = "⚠Error: No se pudo actualizar el turno en la base de datos.";
                }

                gvModificarTurnos.EditIndex = -1;
                cargarGV();
            }
            catch (Exception ex)
            {
                lblModificacionMensaje.Text = "Error inesperado: " + ex.Message;
            }
        }
    }
}