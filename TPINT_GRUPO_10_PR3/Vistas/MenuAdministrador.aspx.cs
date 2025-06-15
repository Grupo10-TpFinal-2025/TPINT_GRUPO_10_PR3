using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGestionMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuGestionMedicos.aspx");
        }

        protected void btnGestionTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuGestionTurnos.aspx");
        }
    }
}