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
            //Codigo para que anden las validaciones
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
            DataTable tabla = disponibilidad.TablaDisponibilidad();
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
            //Me guardo el nombre del dia
            string numeroDia = ((Label)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("lbl_eit_Dia")).Text;

            //Creo un obj disponibilidad
            Disponibilidad disp = new Disponibilidad();

            //Lo paso a numero
            switch (numeroDia)
            {
                case "Lunes":
                    disp.NumDia = 1;
                    break;

                case "Martes":
                    disp.NumDia = 2;
                    break;

                case "Miércoles":
                    disp.NumDia = 3;
                    break;

                case "Jueves":
                    disp.NumDia = 4;
                    break;

                case "Viernes":
                    disp.NumDia = 5;
                    break;

                case "Sábado":
                    disp.NumDia = 6;
                    break;

                case "Domingo":
                    disp.NumDia = 7;
                    break;
            }

            //Seteo el resto de parametros en un objeto disponibilidad 
            disp.LegajoMedico = Convert.ToInt32(((Label)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("lbl_eit_Legajo")).Text);
            disp.Estado = ((CheckBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("cb_eit_Estado")).Checked;
            disp.HorarioInicio = TimeSpan.Parse(((TextBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("txt_eit_Inicio")).Text);
            disp.HorarioFin = TimeSpan.Parse(((TextBox)gvModificacionDisponibilidad.Rows[e.RowIndex].FindControl("txt_eit_Fin")).Text);

            //Ejecuto el update
            if (disponibilidad.ModificarDisponibilidad(disp))
            {
                //Muestro mensaje
                lblMensaje.Text = "Se modifico la base de datos.";
            }
            else
            {
                //Muestro mensaje
                lblMensaje.Text = "No se pudo modificar la base de datos.";
            }

            //Termino la actualizacion
            gvModificacionDisponibilidad.EditIndex = -1;
            cargarGV();

        }
    }
}