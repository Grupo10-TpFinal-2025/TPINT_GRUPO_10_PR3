using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
    public partial class AltaDisponibilidad : System.Web.UI.Page
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
                CargarDias();
            }
        }

        private void CargarDias()
        {
            NegocioDisponibilidad negocioDisponibilidad = new NegocioDisponibilidad();
            DataTable tablaDias = negocioDisponibilidad.ObtenerDias();

            ddlDiasDis.DataSource = tablaDias;
            ddlDiasDis.DataTextField = "Descripcion_DI";
            ddlDiasDis.DataValueField = "NumDia_DI";
            ddlDiasDis.DataBind();

            ddlDiasDis.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
        }

    }
}