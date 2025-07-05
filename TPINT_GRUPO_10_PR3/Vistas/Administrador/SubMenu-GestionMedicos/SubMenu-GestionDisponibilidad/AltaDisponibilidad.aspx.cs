using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
    public partial class AltaDisponibilidad : System.Web.UI.Page
    {
        private NegocioDisponibilidad negocioDisponibilidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarDias();
                CargarDDLHorarioInicio();
                CargarDDLHorarioFin(new TimeSpan(8, 0, 0)); // Inicializa horarios fin
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

            ddlDiasDis.Items.Insert(0, new ListItem("-- Seleccione día --", ""));
        }

        private void CargarDDLHorarioInicio()
        {
            ddlHorarioInicioDis.Items.Clear();
            ddlHorarioInicioDis.Items.Insert(0, new ListItem("-- Seleccione horario --", ""));

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
            ddlHorarioFinDis.Items.Insert(0, new ListItem("-- Seleccione horario --", ""));

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
                // Validación de campos antes de procesar
                if (string.IsNullOrEmpty(txtLegajoDisponibilidad.Text) ||
                    ddlDiasDis.SelectedValue == "" ||
                    ddlHorarioInicioDis.SelectedValue == "" ||
                    ddlHorarioFinDis.SelectedValue == "")
                {
                    lblMensaje.Text = " Por favor complete todos los campos antes de continuar.";
                    LimpiarCampos();
                    return;
                }

                int legajoMedico = int.Parse(txtLegajoDisponibilidad.Text);
                int numDia = int.Parse(ddlDiasDis.SelectedValue);
                TimeSpan horarioInicio = TimeSpan.Parse(ddlHorarioInicioDis.SelectedValue);
                TimeSpan horarioFin = TimeSpan.Parse(ddlHorarioFinDis.SelectedValue);

                if (horarioInicio >= horarioFin)
                {
                    lblMensaje.Text = " El horario de inicio debe ser anterior al de fin.";
                    LimpiarCampos();
                    return;
                }

                negocioDisponibilidad = new NegocioDisponibilidad();

                // Verificar superposición de disponibilidad
                bool existe = negocioDisponibilidad.VerificarDisponibilidad(legajoMedico, numDia);

                if (existe)
                {
                    lblMensaje.Text = " El médico ya tiene una disponibilidad asignada en ese día.";
                    LimpiarCampos();
                    return;
                }

                // Crear disponibilidad y guardar
                Disponibilidad disponibilidad = new Disponibilidad(numDia, legajoMedico, horarioInicio, horarioFin, true);

                int resultado = negocioDisponibilidad.AltaDisponibilidad(disponibilidad);

                if (resultado > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = " Disponibilidad cargada correctamente.";
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = " Error al cargar la disponibilidad.";
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $" Error inesperado: {ex.Message}";
                LimpiarCampos();
            }
        }

        protected void ddlDiasDis_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
        protected void ddlHorarioFinDis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            txtLegajoDisponibilidad.Text = "";
            ddlDiasDis.SelectedIndex = 0;
            ddlHorarioInicioDis.SelectedIndex = 0;
            ddlHorarioFinDis.Items.Clear();
            ddlHorarioFinDis.Items.Insert(0, new ListItem("-- Seleccione horario --", ""));
        }

        protected void ddlHorarioInicioDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHorarioInicioDis.SelectedValue != "")
            {
                TimeSpan horaInicio = TimeSpan.Parse(ddlHorarioInicioDis.SelectedValue);
                CargarDDLHorarioFin(horaInicio);
            }
            else
            {
                ddlHorarioFinDis.Items.Clear();
                ddlHorarioFinDis.Items.Insert(0, new ListItem("-- Seleccione horario --", ""));
            }
        }
    }
}
