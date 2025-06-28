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
        private NegocioDisponibilidad negocioDisponibilidad = new NegocioDisponibilidad();
        private NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        private NegocioMedico negocioMedico = new NegocioMedico();
        private NegocioTurno negocioTurno = new NegocioTurno();

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
            }
        }

        private void CargarDDLEspecialidad()
        {
            try
            {
                ddlEspecialidad.DataSource = negocioEspecialidad.ObtenerListaEspecialidad();
                ddlEspecialidad.DataTextField = "Descripcion_ES";
                ddlEspecialidad.DataValueField = "CodEspecialidad_ES";
                ddlEspecialidad.DataBind();                

                ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));

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
                ddlMedico.DataSource = negocioMedico.ObtenerListaMedicoPorEspecialidad(cod); ;
                ddlMedico.DataTextField = "Medico";
                ddlMedico.DataValueField = "Legajo_ME";
                ddlMedico.DataBind();

                if (cod != "0")
                {
                    ddlMedico.Items.Insert(0, new ListItem("--Seleccione un médico--", "0"));
                }

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
            DateTime fechaActual = DateTime.Now;
            int diaSemana = (int)(DateTime.Now.DayOfWeek + 6) % 7; // Lunes = 0, Domingo = 6

            while (i < 7)
            {
                if (i > 0)
                {
                    fechaActual = fechaActual.AddDays(7);
                }

                DateTime inicioSemana = fechaActual.AddDays(-diaSemana);
                DateTime finSemana = fechaActual.AddDays(6 - diaSemana);

                string texto = $"{inicioSemana:dd-MM} al {finSemana:dd-MM}";
                string valor = inicioSemana.ToString("yyyy-MM-dd"); // valor único

                ddlSemana.Items.Add(new ListItem(texto, valor));
                i++;
            }

            //Session["LegajoMedico"] = Convert.ToInt32(ddlMedico.SelectedValue);
        }

        private void CargarDDLDia(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico = negocioDisponibilidad.ObtenerListaDisponibilidadMedico(legajoMedico);

            ddlDia.Items.Clear();
            ddlDia.DataSource = listaDisponibilidadMedico;
            ddlDia.DataTextField = "NombreDia";
            ddlDia.DataValueField = "NumDia";
            ddlDia.DataBind();
            ddlDia.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
        }

        /*private void CargarDDLHorario()
        {
            int i = 0;

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
        }*/

        public void CargarDDLHorario(int legajoMedico, int numDiaSeleccionado)
        {
            ddlHorario.Items.Clear();

            List<Disponibilidad> listaDisponibilidadMedico = negocioDisponibilidad.ObtenerListaDisponibilidadMedico(legajoMedico);
            List<Turno> listaTurnos = negocioTurno.ObtenerListaTurnos(legajoMedico);
            DateTime fechaSeleccionada = ObtenerFechaSeleccionada();

            // Buscar la disponibilidad correspondiente al día seleccionado
            Disponibilidad disponibilidad = null;

            foreach (Disponibilidad d in listaDisponibilidadMedico)
            {
                if (d.NumDia == numDiaSeleccionado)
                {
                    disponibilidad = d;
                    break;
                }
            }

            // Si no tiene disponibilidad ese día, mostramos un mensaje
            if (disponibilidad == null)
            {
                ddlHorario.Items.Add(new ListItem("No hay horarios disponibles", "0"));
                return;
            }

            // Obtener todas las horas ya ocupadas del médico en esa fecha
            List<TimeSpan> horasOcupadas = new List<TimeSpan>();
            
            foreach (Turno turno in listaTurnos)
            {
                if (turno.Fecha.Date == fechaSeleccionada.Date)
                {
                    horasOcupadas.Add(turno.Fecha.TimeOfDay);
                }
            }

            // Generar las franjas horarias disponibles de 1 hora
            TimeSpan horaInicio = disponibilidad.HorarioInicio;
            TimeSpan horaFin = disponibilidad.HorarioFin;

            while (horaInicio < horaFin)
            {
                TimeSpan siguienteHora = horaInicio.Add(TimeSpan.FromHours(1));
                
                if (!horasOcupadas.Contains(horaInicio))
                {
                    string franja = $"{horaInicio:hh\\:mm} a {siguienteHora:hh\\:mm}";
                    ddlHorario.Items.Add(new ListItem(franja, horaInicio.ToString(@"hh\:mm")));
                }

                horaInicio = siguienteHora;
            }

            ddlHorario.Items.Insert(0, new ListItem("-- Seleccione un horario --", "0"));
        }

        private DateTime ObtenerFechaSeleccionada()
        {
            if (ddlSemana.SelectedIndex <= 0 || ddlDia.SelectedIndex <= 0)
                throw new Exception("Debe seleccionar una semana y un día.");

            // Recuperar la fecha de inicio de la semana desde el Value del ddlSemana
            DateTime fechaInicioSemana = DateTime.ParseExact(ddlSemana.SelectedValue, "yyyy-MM-dd", null);

            // Obtener el número del día (1 = lunes ... 7 = domingo)
            int numDia = int.Parse(ddlDia.SelectedValue);

            // Calcular la fecha exacta del día dentro de esa semana
            DateTime fechaSeleccionada = fechaInicioSemana.AddDays(numDia - 1);

            return fechaSeleccionada;
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = ddlEspecialidad.SelectedValue;

            ddlMedico.Items.Clear();
            ddlSemana.Items.Clear();
            ddlDia.Items.Clear();
            ddlHorario.Items.Clear();

            //Guardar la especialidad seleccionada en Session
            Session["CodigoEspecialidad"] = cod;

            //Cargar médicos y restaurar selección si corresponde
            CargarDDLMedico(cod);
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSemana.Items.Clear();
            ddlDia.Items.Clear();
            ddlHorario.Items.Clear();

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

            if (legajoMedico != 0)
            {
                CargarDDLSemana();
            }

            if (legajoMedico != 0)
            {
                if (ddlSemana.Items.Count == 0)
                {
                    ddlSemana.Items.Add("No hay turnos disponibles para esta semana...");
                    return;
                }
                else
                {
                    ddlSemana.Items.Insert(0, new ListItem("-Seleccione una opcion-", "0"));
                }
            }
        }

        protected void ddlSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDia.Items.Clear();
            ddlHorario.Items.Clear();

            if (ddlSemana.SelectedValue != "0")
            {
                int legajoMedico = Convert.ToInt32(ddlMedico.SelectedValue);

                CargarDDLDia(legajoMedico);
            }
        }

        protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHorario.Items.Clear();

            if (ddlDia.SelectedValue != "0")
            {
                int legajoMedico = Convert.ToInt32(ddlMedico.SelectedValue);
                int diaSeleccionado = int.Parse(ddlDia.SelectedValue);

                CargarDDLHorario(legajoMedico, diaSeleccionado);
            }
        }
    }
}