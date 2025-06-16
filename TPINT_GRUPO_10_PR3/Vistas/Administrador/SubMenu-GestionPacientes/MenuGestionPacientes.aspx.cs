using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarPacientes.aspx");
        }

        protected void btnAltaPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaPaciente.aspx");
        }
    }
}