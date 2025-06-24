using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            Session["Fecha"] = DateTime.Now.Date;

            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarDDLEspecialidad();

                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("--Seleccione un médico--", "0"));
            }
        }

        private void CargarDDLEspecialidad()
        {
            try
            {
                NegocioEspecialidad negocio = new NegocioEspecialidad();
                SqlDataReader reader = negocio.ObtenerListaEspecialidad();

                ddlEspecialidad.DataSource = reader;
                ddlEspecialidad.DataTextField = "Descripcion_ES";
                ddlEspecialidad.DataValueField = "CodEspecialidad_ES";
                ddlEspecialidad.DataBind();                

                ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));

                reader.Close();

                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al cargar especialidades.";                
            }            
        }

        private void CargarDDLMedico(string cod)
        {
            try
            {
                NegocioMedico negocioM = new NegocioMedico();
                SqlDataReader reader = negocioM.ObtenerListaMedicoPorEspecialidad(cod);

                ddlMedico.DataSource = reader;
                ddlMedico.DataTextField = "Medico";
                ddlMedico.DataValueField = "Legajo_ME";
                ddlMedico.DataBind();

                ddlMedico.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));

                reader.Close();
                

                lblError.Visible = false;         
            }

            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al cargar médicos.";
            }            
        }

        private void CargarDDLFechaTurno()
        {
            NegocioTurno negocio = new NegocioTurno();

            //int legajoMedico = Convert.ToInt32(Session["LegajoMedico"]);
            //string nombreDia = Session["NombreDia"].ToString();

            if (Session["ListaTurnosMedico"] != null)
            {
                ddlFechaTurno.DataSource = (List<Turno>)(Session["ListaTurnosMedico"]);
                ddlFechaTurno.DataValueField = "Fecha";
                ddlFechaTurno.DataTextField = "Fecha";
                ddlFechaTurno.DataBind();
            }                       
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
            //Session["NombreMedico"] = ddlMedico.SelectedItem.Text;
            //Session["LegajoMedico"] = ddlMedico.SelectedValue;

            int legajoMedico = Convert.ToInt32(ddlMedico.SelectedValue);
            DateTime fechaActual = (DateTime) Session["Fecha"];

            NegocioDisponibilidad negocioD = new NegocioDisponibilidad();
            
            if(Session["ListaDisponibilidadMedico"] != null)
            {
                Session["ListaDisponibilidadMedico"] = null;
            }

            Session["ListaDisponibilidadMedico"] = negocioD.ObtenerListaDisponibilidadMedico(legajoMedico);

            //-----------------------------------------

            NegocioTurno negocioT = new NegocioTurno();

            if (Session["ListaTurnosMedico"] != null)
            {
                Session["ListaTurnosMedico"] = null;
            }

            Session["ListaTurnosMedico"] = negocioT.ObtenerListaTurnos(legajoMedico);

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