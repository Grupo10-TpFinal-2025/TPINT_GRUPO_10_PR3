using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionTurnos
{
    public partial class AltaTurno : System.Web.UI.Page
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
                CargarDDLEspecialidad();

                ddlMedico.Items.Clear();
                ddlMedico.Items.Add("--Seleccione un médico--");
            }
        }

        private void CargarDDLEspecialidad()
        {
            NegocioEspecialidad negocio = new NegocioEspecialidad();
            SqlDataReader reader = negocio.readerEspecialidad();

            ddlEspecialidad.DataSource = reader;
            ddlEspecialidad.DataTextField = "Descripcion_ES";
            ddlEspecialidad.DataValueField = "CodEspecialidad_ES";
            ddlEspecialidad.DataBind();

            reader.Close();

            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarDDLMedico(string cod)
        {
            NegocioMedico negocio = new NegocioMedico();
            DataTable tabla = negocio.ObtenerTablaMedicoPorEspecialidad(cod);

            ddlMedico.DataSource = tabla;
            ddlMedico.DataTextField = "Medico";
            ddlMedico.DataValueField = "CodigoEspecialidad_ME";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));
        }

        protected void ddlEspecialidad_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string cod = ddlEspecialidad.SelectedValue;
            lblMensaje.Text = string.Empty;

            if (cod == "0")
            {
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("-- Seleccione una especialidad --", "0"));
                return;
            }

            // Solo actualizamos los médicos si cambia la especialidad
            CargarDDLMedico(cod);
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if(ddlMedico.SelectedIndex == 0)
            {
                lblMensaje.Text = string.Empty;
                return;
            }
            lblMensaje.Text = "Médico: " + ddlMedico.SelectedItem.Text + " con Legajo: " + ddlMedico.SelectedValue;
        }        
    }
}