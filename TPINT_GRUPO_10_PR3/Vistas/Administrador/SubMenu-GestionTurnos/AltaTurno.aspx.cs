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
            Session["NumeroDia"] = DateTime.Now.DayOfWeek + 1;

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

        private void CargarDDLSemana()
        {
            //CARGADOS:
            //Turnos para el medico seleccionado:  Session["ListaTurnosMedico"]
            //Disponibilidad semanal del medico seleccionado: Session["ListaDisponibilidadMedico"
            
            if (Session["ListaDisponibilidadMedico"] == null)
            {
                ddlSemana.Text = "No hay horarios disponibles";
                return;
            }

            int i = 0;
            string semana;

            DateTime fechaActual = DateTime.Now;
            int diaSemana = Convert.ToInt32(DateTime.Now.DayOfWeek + 6) % 7;

            while (i < 7)
            {
                if(i > 0)
                {
                    fechaActual = fechaActual.AddDays(7);
                }

                semana = (fechaActual.AddDays(-diaSemana)).ToString("dd-MM") + " al " +
                         (fechaActual.AddDays(6 - diaSemana)).ToString("dd-MM");

                ddlSemana.Items.Add(new ListItem(semana, fechaActual.ToString("MM")));
                i++;
            }
                        
            //Session["LegajoMedico"] = Convert.ToInt32(ddlMedico.SelectedValue);                                                                                               
          }

            
        private void CargarDDLDia(int mes)
        {
            int numDia;
            int i;

            List<Disponibilidad> listaDisponibilidadMedico = (List<Disponibilidad>)Session["ListaDisponibilidadMedico"];

            
        }

        private void CargarDDLHorario()
        {
            int i;

            List<DateTime> horariosDisponibles = new List<DateTime>();
            List<Disponibilidad> listaDisponibilidadMedico = (List<Disponibilidad>)Session["ListaDisponibilidadMedico"];
            List<string> listaHora = new List<string>();


            int horaInicio = Convert.ToInt32(listaDisponibilidadMedico[i].HorarioInicio);
            int horaFin = Convert.ToInt32(listaDisponibilidadMedico[i].HorarioFin);

            int hora = horaFin - horaInicio;

            for (i = 0; i < hora; i++)
            {
                listaHora.Add((hora + i).ToString());
            }

            for (i = 0; i < listaDisponibilidadMedico.Count; i++)
            {
                ddlDia.Items.Add(listaDisponibilidadMedico[i].NombreDia);
            }


            ddlDia.DataSource = listaDisponibilidadMedico;
            ddlDia.DataBind();

            ddlHorario.DataSource = listaHora;
            ddlHorario.DataBind();
        }

        protected void ddlEspecialidad_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string cod = ddlEspecialidad.SelectedValue;
            ddlSemana.Items.Clear();


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
                ddlSemana.Items.Clear();
                return;
            }

            //Guardar selección en Session
            //Session["NombreMedico"] = ddlMedico.SelectedItem.Text;
            //Session["LegajoMedico"] = ddlMedico.SelectedValue;

            int legajoMedico = Convert.ToInt32(ddlMedico.SelectedValue);
            //DateTime fechaActual = (DateTime) Session["DiaSemana"];

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

            CargarDDLSemana();

            if(ddlSemana.Items.Count == 0)
            {                 
                ddlSemana.Items.Add("No hay turnos disponibles para esta semana...");
                return;
            }
            else
            {
                ddlSemana.Items.Insert(0, new ListItem("-Seleccione una opcion-", "0"));
            }

        }

        protected void ddlSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(ddlSemana.SelectedValue);

            CargarDDLDia(mes);
        }
    }
}