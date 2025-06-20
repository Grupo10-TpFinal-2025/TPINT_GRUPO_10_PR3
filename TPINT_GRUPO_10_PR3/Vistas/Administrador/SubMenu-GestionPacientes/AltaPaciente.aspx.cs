using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas.Administrador.SubMenu_GestionPacientes
{
	public partial class AltaPaciente : System.Web.UI.Page
	{

        Paciente paciente = new Paciente();
        NegocioPaciente negocioPaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Manejar la confirmación del usuario
            if (IsPostBack && Request["__EVENTTARGET"] == "btnRegistrarPacienteConfirmado")
            {
                // El usuario confirmo el registro del paciente
                Registrar_AltaPaciente();
            }

            CargarProvincias();
        }

        public void Registrar_AltaPaciente()
        {
            bool resultado = negocioPaciente.AltaPaciente(paciente);

            if (resultado)
            {
                lblMensaje.Text = "Paciente registrado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "Error al registrar el paciente. Intente nuevamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            LimpiarCampos();
        }

        public void CargarProvincias()
        {
            negocioPaciente = new NegocioPaciente();
            ddlProvinciaPaciente.DataSource = negocioPaciente.getRegistrosProvincias();
            ddlProvinciaPaciente.DataTextField = "Descripcion_PR";
            ddlProvinciaPaciente.DataValueField = "CodProvincia_PR";
            ddlProvinciaPaciente.DataBind();
            ddlProvinciaPaciente.Items.Insert(0, new ListItem("Seleccione una provincia", ""));
        }

        public void LimpiarCampos()
        {
            txtDniPaciente.Text = string.Empty;
            txtNombrePaciente.Text = string.Empty;
            txtApellidoPaciente.Text = string.Empty;
            rblSexoPaciente.SelectedIndex = -1; 
            txtNacionalidadPaciente.Text = string.Empty;
            txtFechaNacimientoPaciente.Text = string.Empty;
            txtDireccionPaciente.Text = string.Empty;
            txtLocalidadPaciente.Text = string.Empty;
            ddlProvinciaPaciente.SelectedIndex = 0;
            txtCorreoPaciente.Text = string.Empty;
            txtTelefonoPaciente.Text = string.Empty;
            paciente = new Paciente();

        }

        protected void btnRegistrarPaciente_Click1(object sender, EventArgs e)
        {
            negocioPaciente = new NegocioPaciente();
            paciente.Dni = txtDniPaciente.Text;
            paciente.Nombre = txtNombrePaciente.Text;
            paciente.Apellido = txtApellidoPaciente.Text;
            paciente.Sexo = Convert.ToChar(rblSexoPaciente.SelectedValue);
            paciente.Nacionalidad = txtNacionalidadPaciente.Text;
            paciente.FechaNacimiento = Convert.ToDateTime(txtFechaNacimientoPaciente.Text);
            paciente.Direccion = txtDireccionPaciente.Text;
            paciente.Localidad = txtLocalidadPaciente.Text;
            paciente.Provincia = ddlProvinciaPaciente.SelectedItem.Text;
            paciente.CorreoElectronico = txtCorreoPaciente.Text;
            paciente.Telefono = txtTelefonoPaciente.Text;

            // Verificar si ya existe un paciente con ese DNI
            if (negocioPaciente.VerificarExistenciaPacienteXDNI(paciente))
            {
                // Mostrar confirmación al usuario
                string script = "if(confirm('Ya existe un paciente registrado con ese mismo DNI. ¿Está seguro de que desea registrarlo de todas formas?')) { " +
                               "__doPostBack('btnRegistrarPacienteConfirmado',''); }";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmarRegistro", script, true);
                // Detener ejecución hasta que el usuario confirme
                return;
            }
            Registrar_AltaPaciente();

        }
    }
}