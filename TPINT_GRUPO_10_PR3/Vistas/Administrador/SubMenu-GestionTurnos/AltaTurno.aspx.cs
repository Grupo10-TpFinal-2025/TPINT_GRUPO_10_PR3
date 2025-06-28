using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        private void CargarDDLSemana(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico = negocioDisponibilidad.ObtenerListaDisponibilidadMedico(legajoMedico);
            List<Turno> listaTurnos = negocioTurno.ObtenerListaTurnos(legajoMedico);

            ddlSemana.Items.Clear();

            if (listaDisponibilidadMedico == null || listaDisponibilidadMedico.Count == 0 ||
                listaTurnos == null)
            {
                ddlSemana.Items.Add(new ListItem("No hay horarios disponibles", "0"));
                return;
            }

            DateTime fechaActual = DateTime.Now;
            int diaSemana = (int)(DateTime.Now.DayOfWeek + 6) % 7; // lunes = 0

            for (int i = 0; i < 7; i++)
            {
                if (i > 0)
                    fechaActual = fechaActual.AddDays(7);

                DateTime inicioSemana = fechaActual.AddDays(-diaSemana);
                DateTime finSemana = inicioSemana.AddDays(6);
                int disponiblesEnSemana = 0;

                foreach (var d in listaDisponibilidadMedico)
                {
                    DateTime fechaDelDia = inicioSemana.AddDays(d.NumDia - 1);

                    int cantidadTurnos = 0;
                    foreach (var turno in listaTurnos)
                    {
                        if (turno.Fecha.Date == fechaDelDia.Date)
                            cantidadTurnos++;
                    }

                    int maxTurnos = (int)(d.HorarioFin - d.HorarioInicio).TotalHours;
                    int disponibles = maxTurnos - cantidadTurnos;

                    if (disponibles > 0)
                        disponiblesEnSemana += disponibles;
                }

                if (disponiblesEnSemana > 0)
                {
                    string texto = $"{inicioSemana:dd-MM} al {finSemana:dd-MM} ({disponiblesEnSemana} disponibles)";
                    string valor = inicioSemana.ToString("yyyy-MM-dd");
                    ddlSemana.Items.Add(new ListItem(texto, valor));
                }
            }

            if (ddlSemana.Items.Count == 0)
            {
                ddlSemana.Items.Add(new ListItem("No hay semanas con turnos disponibles", "0"));
            }
        }

        private void CargarDDLDia(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico = negocioDisponibilidad.ObtenerListaDisponibilidadMedico(legajoMedico);
            List<Turno> listaTurnos = negocioTurno.ObtenerListaTurnos(legajoMedico);

            DateTime fechaInicioSemana = DateTime.ParseExact(ddlSemana.SelectedValue, "yyyy-MM-dd", null);

            ddlDia.Items.Clear();

            foreach (var d in listaDisponibilidadMedico)
            {
                // Calcular fecha exacta de ese día en la semana seleccionada
                DateTime fechaDelDia = fechaInicioSemana.AddDays(d.NumDia - 1);


                // Contar cuántos turnos ya hay cargados para ese día
                int cantidadTurnos = 0;
                foreach (var turno in listaTurnos)
                {
                    if (turno.Fecha.Date == fechaDelDia.Date)
                        cantidadTurnos++;
                }

                int maxTurnos = (int)(d.HorarioFin - d.HorarioInicio).TotalHours;
                int disponibles = maxTurnos - cantidadTurnos;

                if (disponibles > 0)
                {
                    string texto = $"{d.NombreDia} ({disponibles} disponibles)";
                    ddlDia.Items.Add(new ListItem(texto, d.NumDia.ToString()));
                }
            }

            ddlDia.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
        }

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
            lblInfoTurnos.Text = string.Empty;

            //Cargar médicos y restaurar selección si corresponde
            CargarDDLMedico(cod);
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSemana.Items.Clear();
            ddlDia.Items.Clear();
            ddlHorario.Items.Clear();
            lblInfoTurnos.Text = string.Empty;

            int legajoMedico = Convert.ToInt32(ddlMedico.SelectedValue);

            List<Disponibilidad> listaDisponibilidadMedico = negocioDisponibilidad.ObtenerListaDisponibilidadMedico(legajoMedico);
            List<Turno> listaTurnos = negocioTurno.ObtenerListaTurnos(legajoMedico);
            
            if (listaTurnos != null)
            {
                int cantidadDisponibles = CalcularTurnosDisponibles(listaDisponibilidadMedico, listaTurnos);

                if (cantidadDisponibles > 0)
                    lblInfoTurnos.Text = $"Este médico tiene {cantidadDisponibles} turnos disponibles en las próximas semanas.";
                else if (ddlMedico.SelectedValue != "0")
                    lblInfoTurnos.Text = "Este médico no tiene turnos próximos disponibles.";
            }
            else
            {
                lblInfoTurnos.Text = "No se encontraron datos de turnos para este médico.";
            }

            if (legajoMedico != 0)
            {
                CargarDDLSemana(legajoMedico);
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
                    ddlSemana.Items.Insert(0, new ListItem("-Seleccione una opción-", "0"));
                }
            }
        }

        public int CalcularTurnosDisponibles(List<Disponibilidad> listaDisponibilidad, List<Turno> listaTurnos)
        {
            int disponibles = 0;
            DateTime hoy = DateTime.Now.Date;
            DateTime fin = hoy.AddDays(49); // 7 semanas completas

            while (hoy <= fin)
            {
                int numDia = (int)(hoy.DayOfWeek + 6) % 7 + 1; // Lunes = 1, Domingo = 7

                foreach (var disp in listaDisponibilidad)
                {
                    if (disp.NumDia != numDia)
                        continue;

                    TimeSpan hora = disp.HorarioInicio;
                    while (hora < disp.HorarioFin)
                    {
                        DateTime posibleTurno = hoy.Add(hora);

                        bool ocupado = false;
                        foreach (var turno in listaTurnos)
                        {
                            if (turno.Estado && turno.Fecha == posibleTurno)
                            {
                                ocupado = true;
                                break;
                            }
                        }

                        if (!ocupado)
                            disponibles++;

                        hora = hora.Add(TimeSpan.FromHours(1));
                    }
                }

                hoy = hoy.AddDays(1);
            }

            return disponibles;
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