using Negocios;
using System;
using System.Collections.Generic;
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
            }
        }

        private void CargarDDLEspecialidad()
        {
            NegocioEspecialidad negocio = new NegocioEspecialidad();
            ddlEspecialidad.DataSource = negocio.readerEspecialidad();
            ddlEspecialidad.DataTextField = "Descripcion_ES";
            ddlEspecialidad.DataValueField = "CodEspecialidad_ES";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
           
        }

        private void CargarDDLMedico()
        {
            string cod = ddlEspecialidad.SelectedValue;

            string medicoSeleccionado = ddlMedico.SelectedValue;

            NegocioMedico negocio = new NegocioMedico();
            SqlDataReader reader = negocio.ObtenerListaMedicoPorEspecialidad(cod);

            ddlMedico.DataSource = reader;
            ddlMedico.DataTextField = "Medico";
            ddlMedico.DataValueField = "CodigoEspecialidad_ME";
            ddlMedico.DataBind();

            reader.Close();

            if (ddlMedico.Items.FindByValue(medicoSeleccionado) != null)
            {
                ddlMedico.SelectedValue = medicoSeleccionado;
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = ddlEspecialidad.SelectedValue;

            if (cod == "0")
            {
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add("-- Seleccione una especialidad --");
                return;
            }

            CargarDDLMedico();
        }

                        
    }
}