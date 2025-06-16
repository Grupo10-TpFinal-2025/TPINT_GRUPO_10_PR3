using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
	public partial class MenuDisponibilidad : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnAltaDisponibilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaDisponibilidad.aspx");
        }

        protected void btnBajaDisponibilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("BajaDisponibilidad.aspx");
        }
    }
}