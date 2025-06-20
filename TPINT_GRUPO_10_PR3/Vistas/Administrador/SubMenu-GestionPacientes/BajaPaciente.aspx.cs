using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas.Administrador.SubMenu_GestionPacientes
{
	public partial class BajaPaciente : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            string dni = txtDNIBaja.Text.Trim();

            if (!string.IsNullOrEmpty(dni))
            {
                NegocioPaciente negocioPaciente = new NegocioPaciente();
                bool exito = negocioPaciente.BajaLogicaPacientePorDNI(dni);

                if (exito)
                {
                    lblResultadoBaja.Text = "Paciente dado de baja exitosamente.";
                    txtDNIBaja.Text = string.Empty;
                }
                else
                {
                    lblResultadoBaja.Text = "No se encontró el paciente o ya estaba dado de baja.";
                }
            }
            else
            {
                lblResultadoBaja.Text = "Por favor, ingresá un DNI válido.";
            }
        }

    }
}