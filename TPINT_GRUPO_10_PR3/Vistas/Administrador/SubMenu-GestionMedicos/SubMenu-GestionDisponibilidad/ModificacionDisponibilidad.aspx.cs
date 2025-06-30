using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Vistas.Administrador.SubMenu_GestionDisponibilidad
{
	public partial class ModificacionDisponibilidad : System.Web.UI.Page
	{
        //Variable del form
        NegocioDisponibilidad disponibilidad = new NegocioDisponibilidad();

        //Page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifico que se haya iniciado como admin
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            //Postback
            if (!IsPostBack)
            {
                //Marco el usuario como admin
                lblUsuarioAdministrador.Text = "Administrador";

                //Cargo la tabla
                cargarGV();
            }
        }

        
        //Funcion cargar gv
        void cargarGV()
        {
            DataTable tabla = disponibilidad.EspecialidadParaModificacion();
            gvModificacionDisponibilidad.DataSource = tabla;
            gvModificacionDisponibilidad.DataBind();
        }

        //Cambio de pagina
        protected void gvModificacionDisponibilidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModificacionDisponibilidad.PageIndex = e.NewPageIndex;
            cargarGV();
        }

        //Edicion de grilla
        protected void gvModificacionDisponibilidad_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificacionDisponibilidad.EditIndex = e.NewEditIndex;
            cargarGV();
        }

        //Cancelar edicion
        protected void gvModificacionDisponibilidad_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Cancelar y cargar gv
            gvModificacionDisponibilidad.EditIndex = -1;
            cargarGV();
        }

        //Actualizar edicion
        protected void gvModificacionDisponibilidad_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Legajo guardado y escondido.
            HiddenField hfLegajo = (HiddenField)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("hf_Legajo");
            int legajo = Convert.ToInt32(hfLegajo.Value);

            //Me guardo el nombre del dia
            string numeroDia = ((Label)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("lbl_eit_Dia")).Text;

            //Lo paso a numero
            switch (numeroDia)
            {
                case "Lunes":
                    numeroDia = "1";
                    break;

                case "Martes":
                    numeroDia = "2";
                    break;

                case "Miércoles":
                    numeroDia = "3";
                    break;

                case "Jueves":
                    numeroDia = "4";
                    break;

                case "Viernes":
                    numeroDia = "5";
                    break;

                case "Sábado":
                    numeroDia = "6";
                    break;

                case "Domingo":
                    numeroDia = "1";
                    break;
            }

            //Creo un obj disponibilidad
            Disponibilidad disp = new Disponibilidad();

            //Seteo los parametros en un objeto disponibilidad
            disp.NumDia = Convert.ToInt32(numeroDia);
            disp.LegajoMedico = legajo;
            disp.Estado = ((CheckBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("cb_eit_Estado")).Checked;
            disp.HorarioInicio = TimeSpan.Parse(((TextBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("lbl_eit_Inicio")).Text);
            disp.HorarioFin = TimeSpan.Parse(((TextBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("lbl_eit_Fin")).Text);

        }
    }
}