using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocios;
using Entidades;


namespace Vistas.Administrador.SubCarpeta_Reportes_Informes
{
	public partial class MenuReportes_Informes : System.Web.UI.Page
	{
        NegocioMedico negocioMedico;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                Session["TablaRedultados"] = null;
                Session["TituloInforme"] = null;
            }
        }


        protected void btnMedicoMasSolicitado_Click(object sender, EventArgs e)
        {
			Response.Redirect("ResultadosReportes-Informes.aspx");
        }

        protected void btnbtnPromedioMEspecialidad_Click(object sender, EventArgs e)
        {
            negocioMedico = new NegocioMedico();
            DataTable tablaCompleta = negocioMedico.ObtenerMedicosXEspecialidad();
            Session["TablaRedultados"] = tablaCompleta;
            Session["TituloInforme"] = "Medicos por Especialidad";
            Response.Redirect("ResultadosReportes-Informes.aspx");
        }

        protected void btnPorcentajePresencialidadT_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResultadosReportes-Informes.aspx");
        }

        protected void btnListarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResultadosReportes-Informes.aspx");
        }
    }
}