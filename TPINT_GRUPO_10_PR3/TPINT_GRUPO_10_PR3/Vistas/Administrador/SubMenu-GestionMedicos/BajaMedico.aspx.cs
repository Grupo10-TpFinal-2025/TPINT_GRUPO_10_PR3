using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Vistas.Administrador.SubMenu_GestionMedicos
{
	public partial class BajaMedico : System.Web.UI.Page
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
            }
        }

        protected void btnBajaMedico_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajoBajaMedico.Text.Trim();

            if (!string.IsNullOrEmpty(legajo))
            {
                NegocioMedico negocioMedico = new NegocioMedico();
                bool exito = negocioMedico.BajaLogicaMedicoPorLegajo(legajo);

                if (exito)
                {
                    lblResultadoBajaMedico.Text = "Paciente dado de baja exitosamente.";
                    txtLegajoBajaMedico.Text = string.Empty;
                }
                else
                {
                    lblResultadoBajaMedico.Text = "No se encontró el paciente o ya estaba dado de baja.";
                }
            }
            else
            {
                lblResultadoBajaMedico.Text = "Por favor, ingresá un legajo válido.";
            }
        }
    }
}