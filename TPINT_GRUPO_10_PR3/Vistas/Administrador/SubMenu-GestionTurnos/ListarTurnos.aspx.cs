using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionTurnos
{
    public partial class ListarTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtListarTurno_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAplicarFiltroAvanzado0_Click(object sender, EventArgs e)
        {
            if(panelListarTurnos.Visible == false)
            {
                panelListarTurnos.Visible = true;
                btnMostrarFiltrosAvanzado0.Text = "Ocultar Filtros Avanzados";
            }

            else
            {
                panelListarTurnos.Visible = false;
                btnMostrarFiltrosAvanzado0.Text = "Aplicar Filtros Avanzados";
            }
        }
    }
}