using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Vistas.Medico
{
    public partial class CambioDeTurno : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["legajo"]  == null)
            {
                lblMensaje.Text = "No se ha logrado encontrar el registro de legajo médico. Por favor, inicie sesión nuevamente.";
            }

            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"].ToString();
            }
        }

        public void CargarTurnosMedico()
        {
            gvActualizacionTurnos.DataSource = negocioTurno.getTurnosXMedico(Convert.ToInt32(Session["legajo"]));
            gvActualizacionTurnos.DataBind();

        }
          
    }
}