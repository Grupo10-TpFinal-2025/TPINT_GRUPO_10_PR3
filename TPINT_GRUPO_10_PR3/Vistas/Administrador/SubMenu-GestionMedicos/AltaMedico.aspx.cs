using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
	public partial class AltaMedico : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Comando para que anden los validators
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            //Pregunto por el postback
            if (!IsPostBack)
            {
                //Cargo los ddl
            }
        }

        protected void btnDisponivilidadMedico_Click(object sender, EventArgs e)
        {
			hlDisponibilidadRapida.Visible = true;
        }

        //Funcion que carga los ddl
        void cargarDDLS()
        {

        }
    }
}