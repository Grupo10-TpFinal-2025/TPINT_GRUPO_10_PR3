using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Administrador.SubMenu_GestionPacientes
{
	public partial class ModificacionPaciente : System.Web.UI.Page
	{
		private NegocioPaciente NegocioPaciente = new NegocioPaciente();
        private Paciente paciente = new Paciente();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuarioAdministrador.Text = "Administrador";
                CargarPacientesTabla();
            }
        }

        public void CargarPacientesTabla()
        {
            gvModificacionPacientes.DataSource = NegocioPaciente.ObtenerPacientes();
            gvModificacionPacientes.DataBind();
        }

        public void ObtenerProvincias(DropDownList ddl)
        {
            ddl.DataSource = NegocioPaciente.getRegistrosProvincias();
            ddl.DataTextField = "Descripcion_PR";
            ddl.DataValueField = "CodProvincia_PR";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void gvModificacionPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModificacionPacientes.EditIndex = -1;
            gvModificacionPacientes.PageIndex = e.NewPageIndex;
            CargarPacientesTabla();
        }

        protected void gvModificacionPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificacionPacientes.EditIndex = -1;
            CargarPacientesTabla();
        }

        protected void gvModificacionPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificacionPacientes.EditIndex = e.NewEditIndex;
            CargarPacientesTabla();
        }

        protected void gvModificacionPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            paciente.Legajo = int.Parse(((Label)gvModificacionPacientes.Rows[e.RowIndex].FindControl("lbl_et_Legajo")).Text);
            paciente.Apellido = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Apellido")).Text;
            paciente.Nombre = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Nombre")).Text;
            paciente.Dni = ((Label)gvModificacionPacientes.Rows[e.RowIndex].FindControl("lbl_et_DNI")).Text;
            paciente.Sexo = ((Label)gvModificacionPacientes.Rows[e.RowIndex].FindControl("lbl_et_Sexo")).Text[0];
            paciente.FechaNacimiento = DateTime.Parse(((Label)gvModificacionPacientes.Rows[e.RowIndex].FindControl("lbl_et_FechaNacimiento")).Text);
            paciente.Nacionalidad = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Nacionalidad")).Text;
            paciente.CodProvincia = int.Parse(((DropDownList)gvModificacionPacientes.Rows[e.RowIndex].FindControl("ddl_et_Provincias")).SelectedValue);
            paciente.Localidad = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Localidad")).Text;
            paciente.Direccion = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Direccion")).Text;
            paciente.CorreoElectronico = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Correo")).Text;
            paciente.Telefono = ((TextBox)gvModificacionPacientes.Rows[e.RowIndex].FindControl("txt_et_Telefono")).Text;

            if (NegocioPaciente.ModificarPaciente(paciente))
            {
                lblMensaje.Text = "Médico modificado correctamente.";
                gvModificacionPacientes.EditIndex = -1;
                CargarPacientesTabla();
            }
            else
            {
                lblMensaje.Text = "Error al modificar el médico. Verifique los datos ingresados.";
            }
        }

        protected void gvModificacionPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Nos aseguramos de que es una fila de datos
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Verificamos si la fila está en modo de edición
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //Encontrar el control DropDownList dentro de la fila
                    DropDownList ddlProvincias = (DropDownList)e.Row.FindControl("ddl_et_Provincias");

                    //Llamar al metodo para cargar los datos en el DropDownList
                    ObtenerProvincias(ddlProvincias);

                    //Seleccionar la provincia actual obteniendo el ID de la provincia  de la fila seleccionada.
                    string IDProvincia = DataBinder.Eval(e.Row.DataItem, "CodProvincia").ToString();

                    // Busco y selecciono el item en el DropDownList
                    ListItem item = ddlProvincias.Items.FindByValue(IDProvincia);
                    if (item != null)
                    {
                        ddlProvincias.SelectedValue = IDProvincia;
                    }
                    else
                    {
                        // Si no se encuentra se selecciona el primer item
                        ddlProvincias.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}