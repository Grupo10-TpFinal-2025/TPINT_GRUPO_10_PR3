using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
using static System.Collections.Specialized.BitVector32;

namespace Vistas.Administrador.SubMenu_GestionPacientes
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        NegocioPaciente negocioPaciente = new NegocioPaciente();
        Paciente paciente = new Paciente();
        private bool[,] filtros = new bool[3, 3];
        bool FiltrosAvanzados = false;
        DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarTablaPacientes();
            }


        }

        public void CargarTablaPacientes()
        {
            gvListadoPacientes.DataSource = negocioPaciente.ObtenerPacientes();
            gvListadoPacientes.DataBind();
        }

        protected void btnMenuFiltrosAvanzados_Click(object sender, EventArgs e)
        {

            if (btnMenuFiltrosAvanzados.Text == "Aplicar filtros avanzados")
            {
                pnlFiltrosAvanzados.Visible = true;
                btnMenuFiltrosAvanzados.Text = "Ocultar filtros avanzados";
            }
            else
            {
                pnlFiltrosAvanzados.Visible = false;
                btnMenuFiltrosAvanzados.Text = "Aplicar filtros avanzados";
            }
        }

        protected void btnProvincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FiltoProvincias")
            {
                paciente.CodProvincia = Convert.ToInt32(e.CommandArgument);
                dataTable = negocioPaciente.ObtenerPacientes_Filtrados(paciente, FiltrosAvanzados, filtros); 
                gvListadoPacientes.DataSource = dataTable;
                gvListadoPacientes.DataBind();

                paciente.CodProvincia = 0;
            }
        }

        private bool[,] VerificarFiltroAvanzado()
        {
            if (IsFiltrosVacios())
            {
                return filtros;
            }

            if (txtIDniPaciente.Text.Trim().Length > 0)
            {
                switch (ddlOperatorsDni.SelectedValue)
                {
                    case "1":
                        filtros[0, 0] = true;
                        break;

                    case "2":
                        filtros[0, 1] = true;
                        break;

                    case "3":
                        filtros[0, 2] = true;
                        break;
                }
            }

            if (txtNombrePaciente.Text.Trim().Length > 0)
            {
                switch (ddlOperatorsNombre.SelectedValue)
                {
                    case "1":
                        filtros[1, 0] = true;
                        break;

                    case "2":
                        filtros[1, 1] = true;
                        break;

                    case "3":
                        filtros[1, 2] = true;
                        break;
                }
            }

            if (txtTelefonoPaciente.Text.Trim().Length > 0)
            {
                switch (ddlOperatorsTelefono.SelectedValue)
                {
                    case "1":
                        filtros[2, 0] = true;
                        break;

                    case "2":
                        filtros[2, 1] = true;
                        break;

                    case "3":
                        filtros[2, 2] = true;
                        break;
                }
            }

            return filtros;
        }

        public bool IsFiltrosVacios()
        {
            if (string.IsNullOrWhiteSpace(txtIDniPaciente.Text) && string.IsNullOrWhiteSpace(txtNombrePaciente.Text) && string.IsNullOrWhiteSpace(txtTelefonoPaciente.Text))
            {
                return true;
            }
            return false;
        }

        protected void btnAplicarFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                FiltrosAvanzados = true;
                txtFiltroDNIPaciente.Text = string.Empty;

                paciente.Dni = txtFiltroDNIPaciente.Text.Trim();
                paciente.Nombre = txtNombrePaciente.Text.Trim();
                paciente.Telefono = txtTelefonoPaciente.Text.Trim();

                if (IsFiltrosVacios())
                {
                    lblFiltrosAvanzadosVacios.Text = "No se llenó ningún filtro particular.";
                    return;
                }
                else
                {
                    lblFiltrosAvanzadosVacios.Text = string.Empty;
                }

                filtros = VerificarFiltroAvanzado();

                DataTable tablaFiltrada = negocioPaciente.ObtenerPacientes_Filtrados(paciente, FiltrosAvanzados, filtros);

                if (tablaFiltrada.Rows.Count == 0)
                {
                    lblFiltrosAvanzadosVacios.Text = "No se encontraron resultados con los filtros aplicados.";
                    gvListadoPacientes.DataSource = null;
                    gvListadoPacientes.DataBind();
                }
                else
                {
                    dataTable = tablaFiltrada;
                    gvListadoPacientes.DataSource = dataTable;
                    gvListadoPacientes.DataBind();
                }
                paciente = new Paciente();
            }
        }


        public void LimpiarFiltrosAvanzados()
        {
            txtIDniPaciente.Text = string.Empty;
            txtNombrePaciente.Text = string.Empty;
            txtTelefonoPaciente.Text = string.Empty;
            ddlOperatorsDni.SelectedIndex = 0;
            ddlOperatorsNombre.SelectedIndex = 0;
            ddlOperatorsTelefono.SelectedIndex = 0;
            filtros = new bool[3, 3];
            FiltrosAvanzados = false;
        }

        protected void btnLimpiarFiltrosPacientes_Click(object sender, EventArgs e)
        {
            if (IsFiltrosVacios())
            {
                lblFiltrosAvanzadosVacios.Text = "No se llenó ningún filtro particular.";
                return;
            }
            else
            {
                LimpiarFiltrosAvanzados();
                gvListadoPacientes.PageIndex = 0;
                CargarTablaPacientes();
            }

            lblFiltrosAvanzadosVacios.Text = string.Empty;
        }

        protected void btnFiltrarPacienteDNI_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                FiltrosAvanzados = false;
                txtFiltroDNIPaciente.Text = string.Empty;
                lblFiltrosAvanzadosVacios.Text = string.Empty;

                paciente.Dni = txtFiltroDNIPaciente.Text.Trim();
                DataTable tablaFiltrada = negocioPaciente.ObtenerPacientes_Filtrados(paciente, FiltrosAvanzados, filtros);
                
                if (tablaFiltrada.Rows.Count == 0)
                {
                    lblDNInoEncontrado.Text = "El DNI ingresado no existe.";
                    dataTable = null;
                    gvListadoPacientes.DataSource = dataTable;
                    gvListadoPacientes.DataBind();
                }
                else
                {
                    lblDNInoEncontrado.Text = string.Empty;
                    dataTable = tablaFiltrada;
                    gvListadoPacientes.DataSource = dataTable;
                    gvListadoPacientes.DataBind();
                }
                paciente = new Paciente(); 
            }
        }

        protected void btnMostrarTodosPacientes_Click(object sender, EventArgs e)
        {
            FiltrosAvanzados = false;

            LimpiarFiltrosAvanzados();
            txtFiltroDNIPaciente.Text = string.Empty;
            lblDNInoEncontrado.Text = string.Empty;
            dataTable = null;

            gvListadoPacientes.PageIndex = 0; 
            CargarTablaPacientes();

            
        }

        protected void gvListadoPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoPacientes.PageIndex = e.NewPageIndex;
            if (FiltrosAvanzados || dataTable.Rows.Count > 0)
            {
                gvListadoPacientes.DataSource = negocioPaciente.ObtenerPacientes_Filtrados(paciente, FiltrosAvanzados, filtros);
            }
            else
            {
                gvListadoPacientes.DataSource = negocioPaciente.ObtenerPacientes();
            }
        }
    }
}