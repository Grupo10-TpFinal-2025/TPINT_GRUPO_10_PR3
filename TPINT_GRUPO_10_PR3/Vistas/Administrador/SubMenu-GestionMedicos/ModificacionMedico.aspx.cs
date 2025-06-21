using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Negocios;
using Entidades;

namespace Vistas.Administrador.SubMenu_GestionMedicos
{
	public partial class ModificacionMedico : System.Web.UI.Page
	{
        private NegocioMedico negocioMedico;
        private Entidades.Medico medico;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CagarMedicosTabla();
            }
            else
            {
                lblMensaje.Text = string.Empty;
            }
        }

        public void CagarMedicosTabla()
        {
            negocioMedico = new NegocioMedico();
            gvModificacionMedicos.DataSource = negocioMedico.ObtenerMedicos();
            gvModificacionMedicos.DataBind();

        }

        protected void gvModificacionMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModificacionMedicos.PageIndex = e.NewPageIndex;
            CagarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificacionMedicos.PageIndex = e.NewEditIndex;
            CagarMedicosTabla();

        }

        protected void gvModificacionMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificacionMedicos.EditIndex = -1;
            CagarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            medico.Legajo = int.Parse(((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Legajo")).Text);
            medico.Nombre = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nombre")).Text;
            medico.Apellido = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Apellido")).Text;
            medico.Sexo = ((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Sexo")).Text[0];
            medico.FechaNacimiento = DateTime.Parse(((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_FechaNacimiento")).Text);
            medico.Nacionalidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nacionalidad")).Text;
            medico.CodigoProvincia = int.Parse(((DropDownList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("ddl_et_Provincia")).SelectedValue);
            medico.Localidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Localidad")).Text;
            medico.Direccion = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Direccion")).Text;
            medico.Correo = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Correo")).Text;
            medico.Telefono = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Telefono")).Text;
            medico.CodigoEspecialidad = int.Parse(((DropDownList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Especialidad")).Text);

            if (negocioMedico.ModificarMedico(medico))
            {
                lblMensaje.Text = "Médico modificado correctamente.";
                gvModificacionMedicos.EditIndex = -1;
                CagarMedicosTabla();
            }
            else
            {
                lblMensaje.Text = "Error al modificar el médico. Verifique los datos ingresados.";

            }
        }


    }
}
