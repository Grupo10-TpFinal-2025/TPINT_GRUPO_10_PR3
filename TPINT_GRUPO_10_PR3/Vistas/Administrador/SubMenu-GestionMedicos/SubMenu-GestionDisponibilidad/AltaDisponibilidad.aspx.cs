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
        private NegocioDisponibilidad negocioDisponibilidad;
        
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
                CargarDDLHorarioInicio();
            }
        }

        private void CargarDias()
        {
            negocioDisponibilidad = new NegocioDisponibilidad();
            DataTable tablaDias = negocioDisponibilidad.ObtenerDias();

            ddlDiasDis.DataSource = tablaDias;
            ddlDiasDis.DataTextField = "Descripcion_DI";
            ddlDiasDis.DataValueField = "NumDia_DI";
            ddlDiasDis.DataBind();

            ddlDiasDis.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
        }

        private void CargarDDLHorarioInicio()
        {
            ddlHorarioInicioDis.Items.Clear();
            ddlHorarioInicioDis.Items.Insert(0, new ListItem("-- Hora inicio --", ""));

            TimeSpan horaInicio = new TimeSpan(8, 0, 0); // 08:00
            TimeSpan horaFin = new TimeSpan(19, 0, 0);   // hasta 19:00
            TimeSpan intervalo = new TimeSpan(1, 0, 0);

            TimeSpan actual = horaInicio;
            while (actual <= horaFin)
            {
                string horaStr = actual.ToString(@"hh\:mm");
                ddlHorarioInicioDis.Items.Add(new ListItem(horaStr, horaStr));
                actual = actual.Add(intervalo);
            }
        }

        private void CargarDDLHorarioFin(TimeSpan horaInicio)
        {
            ddlHorarioFinDis.Items.Clear();
            ddlHorarioFinDis.Items.Insert(0, new ListItem("-- Hora fin --", ""));

            TimeSpan horaMax = new TimeSpan(20, 0, 0); // 20:00
            TimeSpan intervalo = new TimeSpan(1, 0, 0);

            TimeSpan actual = horaInicio.Add(intervalo);
            while (actual <= horaMax)
            {
                string horaStr = actual.ToString(@"hh\:mm");
                ddlHorarioFinDis.Items.Add(new ListItem(horaStr, horaStr));
                actual = actual.Add(intervalo);
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

                negocioDisponibilidad = new NegocioDisponibilidad();

                // Verificar superposición
                bool existe = negocioDisponibilidad.VerificarDisponibilidad(legajoMedico, numDia);

                if (existe)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "El médico ya tiene una disponibilidad asignada en ese día.";
                    return;
                }

                // Crear disponibilidad y guardar
                Disponibilidad disponibilidad = new Disponibilidad(numDia, legajoMedico, horarioInicio, horarioFin, true);

                int resultado = negocioDisponibilidad.AltaDisponibilidad(disponibilidad);

                if (resultado > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Disponibilidad cargada correctamente.";
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Error al cargar la disponibilidad.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
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

        protected void ddlDiasDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlDiasDis.SelectedIndex != 0)
            {
                ddlDiasDis.Items[0].Enabled = false;
            }
        }

        protected void ddlHorarioInicioDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlHorarioInicioDis.SelectedIndex != 0)
            {
                ddlHorarioInicioDis.Items[0].Enabled = false;

                TimeSpan horaInicio = TimeSpan.Parse(ddlHorarioInicioDis.SelectedValue);
                CargarDDLHorarioFin(horaInicio);
            }
        }

        protected void ddlHorarioFinDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHorarioFinDis.SelectedIndex != 0)
            {
                ddlHorarioFinDis.Items[0].Enabled = false;
            }
        }
    }
}