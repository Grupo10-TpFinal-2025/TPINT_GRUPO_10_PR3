using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
    public partial class AltaDisponibilidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarDias();
                CargarHorarios();
            }
        }

        private void CargarDias()
        {
            NegocioDisponibilidad negocioDisponibilidad = new NegocioDisponibilidad();
            DataTable tablaDias = negocioDisponibilidad.ObtenerDias();

            ddlDiasDis.DataSource = tablaDias;
            ddlDiasDis.DataTextField = "Descripcion_DI";
            ddlDiasDis.DataValueField = "NumDia_DI";
            ddlDiasDis.DataBind();

            ddlDiasDis.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
        }

        private void CargarHorarios()
        {
            ddlHorarioInicioDis.Items.Clear();
            ddlHorarioFinDis.Items.Clear();

            ddlHorarioInicioDis.Items.Add(new ListItem("-- Hora inicio --", ""));
            ddlHorarioFinDis.Items.Add(new ListItem("-- Hora fin --", ""));

            TimeSpan hora = new TimeSpan(8, 0, 0); // 08:00
            TimeSpan horaFin = new TimeSpan(20, 0, 0); // 20:00
            TimeSpan intervalo = new TimeSpan(0, 30, 0); // 30 minutos

            while (hora <= horaFin)
            {
                string horaStr = hora.ToString(@"hh\:mm"); // Formato 08:00
                ddlHorarioInicioDis.Items.Add(new ListItem(horaStr, horaStr));
                ddlHorarioFinDis.Items.Add(new ListItem(horaStr, horaStr));
                hora = hora.Add(intervalo);
            }
        }

        protected void btnAgregarDisponibilidad_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.ForeColor = System.Drawing.Color.Red;

            try
            {
                int legajoMedico = int.Parse(txtLegajoDisponibilidad.Text);
                int numDia = int.Parse(ddlDiasDis.SelectedValue);
                TimeSpan horarioInicio = TimeSpan.Parse(ddlHorarioInicioDis.SelectedValue);
                TimeSpan horarioFin = TimeSpan.Parse(ddlHorarioFinDis.SelectedValue);

                // Validar horario correcto
                if (horarioInicio >= horarioFin)
                {
                    lblMensaje.Text = "El horario de inicio debe ser menor al horario de fin.";
                    return;
                }

                NegocioDisponibilidad negocio = new NegocioDisponibilidad();

                // Verificar superposición
                bool existe = negocio.VerificarDisponibilidad(legajoMedico, numDia, horarioInicio, horarioFin);

                if (existe)
                {
                    lblMensaje.Text = "El médico ya tiene una disponibilidad asignada en ese día y horario.";
                    return;
                }

                // Crear disponibilidad y guardar
                Disponibilidad disponibilidad = new Disponibilidad(numDia, legajoMedico, horarioInicio, horarioFin, true);

                int resultado = negocio.AltaDisponibilidad(disponibilidad);

                if (resultado > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Disponibilidad cargada correctamente.";
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "Error al cargar la disponibilidad.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error inesperado: {ex.Message}";
            }
        }

        private void LimpiarCampos()
        {
            ddlDiasDis.SelectedIndex = 0;
            txtLegajoDisponibilidad.Text = "";
            ddlHorarioInicioDis.SelectedIndex = 0;
            ddlHorarioFinDis.SelectedIndex = 0;
        }

    }
}