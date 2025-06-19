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

		}

        protected void btnMedicoMasSolicitado_Click(object sender, EventArgs e)
        {
			Response.Redirect("ResultadosReportes-Informes.aspx");
        }

        protected void btnbtnPromedioMEspecialidad_Click(object sender, EventArgs e)
        {
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