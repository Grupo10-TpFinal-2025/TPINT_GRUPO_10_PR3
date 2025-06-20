using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
	public partial class AltaMedico : System.Web.UI.Page
	{
        //Variables globales
        NegocioMedico negocioMedico = new NegocioMedico();

		protected void Page_Load(object sender, EventArgs e)
		{
            //Comando para que anden los validators
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            //Pregunto por el postback
            if (!IsPostBack)
            {
                //Cargo los ddl
                CargarDDLS();
            }
        }

        //Evento click "Agregar"
        protected void btnDisponivilidadMedico_Click(object sender, EventArgs e)
        {
			hlDisponibilidadRapida.Visible = true;
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
    }
}