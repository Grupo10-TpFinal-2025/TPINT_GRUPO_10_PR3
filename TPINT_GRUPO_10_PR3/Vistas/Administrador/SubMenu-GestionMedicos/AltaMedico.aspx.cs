
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas.Administrador.SubMenu_GestionMedico
{
	public partial class AltaMedico : System.Web.UI.Page
	{
        //Variables globales
        NegocioMedico negocioMedico = new NegocioMedico();

        //Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // Verificar si hay sesión activa
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return; // para evitar que siga ejecutando el resto si redirige
            }

            // Ejecutar solo la primera vez que carga la página
            if (!IsPostBack)
            {
                CargarDDLS(); // Cargar los DropDownList
                lblUsuarioAdministrador.Text = "Administrador";

                //Obtener la fecha actual.
                DateTime hoy = DateTime.Today;

                //Calcular la fecha límite restando 18 años a la fecha de hoy (cualquier persona nacida después de esta fecha es menor de edad).
                DateTime fechaMaximaPermitida = hoy.AddYears(-18);

                //Formatear la fecha al estándar "yyyy-MM-dd" que entiende <input type="date">
                string fechaMaximaFormateada = fechaMaximaPermitida.ToString("yyyy-MM-dd");

                //Asignar la fecha calculada como el atributo 'max' del control.
                txtFechaNacimientoMedico.Attributes["max"] = fechaMaximaFormateada;
            }
        }

        //Evento click "Agregar"
        protected void btnDisponivilidadMedico_Click(object sender, EventArgs e)
        {
            //Variable
            bool bandera = false;

            //Cargo los valores en un objeto medico
            Entidades.Medico medico = CargaMedico();
            if (negocioMedico.ValidarExistenciaMedicoXDNI(medico) > 0)
            {
                string script = "if(confirm('Ya existe un medico registrado con ese mismo DNI. ¿Está seguro de que desea registrarlo de todas formas?')) { " +
                        "__doPostBack('" + btnAux.UniqueID + "',''); " +
                        "}";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmarRegistro", script, true);
            }
            else
            {
                //Subo el objeto medico a la bd
                bandera = negocioMedico.AgregarMedico(medico);

                //Si todo salio bien
                if (bandera)
                {
                    //Doy opcion a cargar las disponibilidades del medico
                    hlDisponibilidadRapida.Visible = true;

                    //borro los campos en el formulario
                    LimpiarCampos();

                    //Mensaje de exito al cargar medico
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Se ha cargado con exito al sistema.";
                }
                else
                {
                    //Mensaje de error
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Ha ocurrido un error.";
                }
            }
        }

        protected void btnAux_Click(object sender, EventArgs e)
        {
            bool bandera = false;
           Entidades.Medico medico = CargaMedico();

            bandera = negocioMedico.AgregarMedico(medico);

            if (bandera)
            {
                hlDisponibilidadRapida.Visible = true;

                LimpiarCampos();

                //Mensaje de exito al cargar medico
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Medico duplicado registrado exitosamente según su confirmación.";
                lblMensaje.CssClass = "mensaje-exito";
            }
            else
            {
                //Mensaje de error
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                lblMensaje.Text = "Ha ocurrido un error";
                lblMensaje.CssClass = "mensaje-error";
            }
        }

        //Funcion que carga los ddl
        void CargarDDLS()
        {
            //Agrego la especialidad
            ddlEspecialidadMedico.DataSource = negocioMedico.readerEspecialidad();

            //Seteo sus parametros
            ddlEspecialidadMedico.DataTextField = "Descripcion_ES";
            ddlEspecialidadMedico.DataValueField = "CodEspecialidad_ES";
            ddlEspecialidadMedico.DataBind();

            //Agrego las provincias
            ddlProvinciaMedico.DataSource = negocioMedico.readerProvincias();

            //Seteo sus parametros
            ddlProvinciaMedico.DataTextField = "Descripcion_PR";
            ddlProvinciaMedico.DataValueField = "CodProvincia_PR";
            ddlProvinciaMedico.DataBind();

            //Seteo valores predeterminados en el 0 de ambos ddl
            ddlProvinciaMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            ddlEspecialidadMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        
        //Funcion de guarda valores en variable medico
        Entidades.Medico CargaMedico()
        {
            //Creo a medico
            Entidades.Medico medico = new Entidades.Medico();

            //Le cargo los valores
            medico.Legajo = 0;
            medico.Nombre = txtNombreMedico.Text.Trim();
            medico.Apellido = txtApellidoMedico.Text.Trim();
            medico.Sexo = Convert.ToChar(rblSexoMedico.SelectedValue);
            medico.Nacionalidad = txtNacionalidadMedico.Text.Trim();
            medico.FechaNacimiento = Convert.ToDateTime(txtFechaNacimientoMedico.Text);
            medico.Direccion = txtDireccionMedico.Text.Trim();
            medico.Localidad = txtLocalidadMedico.Text.Trim();
            medico.CodigoProvincia = Convert.ToInt32(ddlProvinciaMedico.SelectedValue);
            medico.Correo = txtCorreoMedico.Text.Trim();
            medico.Telefono = txtTelefonoMedico.Text.Trim();
            medico.CodigoEspecialidad = Convert.ToInt32(ddlEspecialidadMedico.SelectedValue);
            medico.DNI = txtDniMedico.Text.Trim();
            medico.Estado = true;

            return medico;
        }

        //funcion que limpia campos
        void LimpiarCampos()
        {
            //Limpio los txtBox
            txtApellidoMedico.Text = string.Empty;
            txtNombreMedico.Text = string.Empty;
            txtCorreoMedico.Text = string.Empty;
            txtDireccionMedico.Text = string.Empty;
            txtDniMedico.Text = string.Empty;
            txtFechaNacimientoMedico.Text = string.Empty;
            txtLocalidadMedico.Text = string.Empty;
            txtNacionalidadMedico.Text = string.Empty;
            txtTelefonoMedico.Text = string.Empty;

            //Activo la opcion default y limpio los ddl
            ddlProvinciaMedico.Items[0].Enabled = true;
            ddlEspecialidadMedico.Items[0].Enabled = true;
            ddlEspecialidadMedico.SelectedIndex = 0;
            ddlProvinciaMedico.SelectedIndex = 0;
        }

        //Evento selected index change provincia
        protected void ddlProvinciaMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si la opcion ya no es 0
            if(ddlProvinciaMedico.SelectedIndex != 0)
            {
                //Desactivar la opcion 0
                ddlProvinciaMedico.Items[0].Enabled = false;
            }
        }

        //Evento selected index change especialidad
        protected void ddlEspecialidadMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si la opcion ya no es 0
            if (ddlEspecialidadMedico.SelectedIndex != 0)
            {
                //Desactivar la opcion 0
                ddlEspecialidadMedico.Items[0].Enabled = false;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            ClientScript.RegisterForEventValidation(btnAux.UniqueID);
            base.Render(writer);
        }
    }
}