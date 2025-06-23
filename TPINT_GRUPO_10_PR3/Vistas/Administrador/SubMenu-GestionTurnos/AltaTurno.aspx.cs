using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionTurnos
{
    public partial class AltaTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["NombreDia"] = DateTime.Now.ToString("dddd");

            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarDDLEspecialidad();

                lblMensaje.Text = (string)Session["NombreDia"];

                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("--Seleccione un médico--", "0"));
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

            ddlMedico.DataSource = negocio.ObtenerTablaMedicoPorEspecialidad(cod);
            ddlMedico.DataTextField = "Medico";
            ddlMedico.DataValueField = "Legajo_ME";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));

            //Restaurar selección si hay una guardada en Session
            if (Session["LegajoMedico"] != null)
            {
                string legajo = Session["LegajoMedico"].ToString();
                if (ddlMedico.Items.FindByValue(legajo) != null)
                {
                    ddlMedico.SelectedValue = legajo;
                }
            }
        }

        private void CargarDDLFechaTurno()
        {
            NegocioDisponibilidad negocio = new NegocioDisponibilidad();

            int legajoMedico = Convert.ToInt32(Session["LegajoMedico"]);

            SqlDataReader reader = negocio.MostrarDisponibilidad(legajoMedico, (string)Session["NombreDia"]);

            ddlFechaTurno.DataSource = reader;
            ddlFechaTurno.DataValueField = "NumeroDia";
            ddlFechaTurno.DataTextField = "NombreDia";
            ddlFechaTurno.DataBind();

            reader.Close();

        }

        protected void ddlEspecialidad_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string cod = ddlEspecialidad.SelectedValue;
            ddlFechaTurno.Items.Clear();


            if (cod == "0")
            {
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("-- Seleccione una especialidad --", "0"));
                return;
            }

            //Guardar la especialidad seleccionada en Session
            Session["CodigoEspecialidad"] = cod;

            //Cargar médicos y restaurar selección si corresponde
            CargarDDLMedico(cod);

        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMedico.SelectedIndex == 0)
            {
                ddlFechaTurno.Items.Clear();
                return;
            }

            //Guardar selección en Session
            Session["NombreMedico"] = ddlMedico.SelectedItem.Text;
            Session["LegajoMedico"] = ddlMedico.SelectedValue;

            CargarDDLFechaTurno();

            if(ddlFechaTurno.Items.Count == 0)
            {                 
                ddlFechaTurno.Items.Add("No hay turnos disponibles para esta semana...");
                return;
            }
            else
            {
                ddlFechaTurno.Items.Insert(0, new ListItem("-Seleccione una opcion-", "0"));
            }

        }        
    }
}