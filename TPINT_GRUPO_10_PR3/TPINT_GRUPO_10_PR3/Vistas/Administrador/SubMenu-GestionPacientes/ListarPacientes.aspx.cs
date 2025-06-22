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
                CargarProvincias();
                Session["TablaFiltrada"] = null;
            }
        }

        public void CargarProvincias()
        {
            gvProvincias.DataSource = negocioPaciente.getRegistrosProvincias();
            gvProvincias.DataBind();
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

                DataTable tablaFiltrada = negocioPaciente.ObtenerPacientes_Filtrados(paciente, true, filtros);
                Session["TablaFiltrada"] = tablaFiltrada;

                if (tablaFiltrada.Rows.Count == 0)
                {
                    lblFiltrosAvanzadosVacios.Text = "No se encontraron resultados con los filtros aplicados.";
                }

                gvListadoPacientes.DataSource = tablaFiltrada;
                gvListadoPacientes.DataBind();
                gvListadoPacientes.PageIndex = 0; 
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
                Session["TablaFiltrada"] = null;
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
                txtFiltroDNIPaciente.Text = string.Empty;
                lblFiltrosAvanzadosVacios.Text = string.Empty;

                paciente.Dni = txtFiltroDNIPaciente.Text.Trim();
                DataTable tablaFiltrada = negocioPaciente.ObtenerPacientes_Filtrados(paciente, false, filtros);
                Session["TablaFiltrada"] = tablaFiltrada;

                if (tablaFiltrada.Rows.Count == 0)
                {
                    lblDNInoEncontrado.Text = "El DNI ingresado no existe.";
                }
                else
                {
                    lblDNInoEncontrado.Text = string.Empty;
                }

                gvListadoPacientes.DataSource = tablaFiltrada;
                gvListadoPacientes.DataBind();
                gvListadoPacientes.PageIndex = 0;
                paciente = new Paciente(); 
            }
        }

        protected void btnMostrarTodosPacientes_Click(object sender, EventArgs e)
        {
            LimpiarFiltrosAvanzados();
            txtFiltroDNIPaciente.Text = string.Empty;
            lblDNInoEncontrado.Text = string.Empty;
            Session["TablaFiltrada"] = null;

            gvListadoPacientes.PageIndex = 0; 
            CargarTablaPacientes();
        }

        protected void gvListadoPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoPacientes.PageIndex = e.NewPageIndex;
            if (Session["TablaFiltrada"] != null)
            {
                gvListadoPacientes.DataSource = Session["TablaFiltrada"];
            }
            else
            {
                gvListadoPacientes.DataSource = negocioPaciente.ObtenerPacientes();
            }

            gvListadoPacientes.DataBind();
        }

        protected void btnProvincia_Command1(System.Object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "FiltoProvincias")
            {
                paciente.CodProvincia = Convert.ToInt32(e.CommandArgument);
                Session["TablaFiltrada"] = negocioPaciente.ObtenerPacientes_Filtrados(paciente, false, filtros);
                gvListadoPacientes.DataSource = Session["TablaFiltrada"];
                gvListadoPacientes.DataBind();

                gvListadoPacientes.PageIndex = 0;
                paciente.CodProvincia = 0;
            }

        }
    }
}