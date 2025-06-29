using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubCarpeta_Reportes_Informes
{
	public partial class MenuReportes_Informes : System.Web.UI.Page
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


        protected void btnMedicoMasSolicitado_Click(object sender, EventArgs e)
        {
			Response.Redirect("ResultadosReportes-Informes.aspx");
        }

        protected void btnbtnPromedioMEspecialidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResultadosReportes-Informes.aspx");

            negocioMedico = new NegocioMedico();
            DataTable tablaCompleta = negocioMedico.ObtenerMedicosXEspecialidad();
            Session["TablaRedultados"] = tablaCompleta;
            Session["Titulo"] = "Medicos por Especialidad";


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