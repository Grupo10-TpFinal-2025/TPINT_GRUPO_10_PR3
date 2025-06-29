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
using System.Web.DynamicData;

namespace Vistas.Administrador.SubMenu_GestionMedicos
{
	public partial class ModificacionMedico : System.Web.UI.Page
	{
        private NegocioMedico negocioMedico;
        private Entidades.Medico medico;

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
                CargarMedicosTabla();
            }
            else
            {
                lblMensaje.Text = string.Empty;
            }
        }

        public void CargarMedicosTabla()
        {
            negocioMedico = new NegocioMedico();
            gvModificacionMedicos.DataSource = negocioMedico.ObtenerMedicos();
            gvModificacionMedicos.DataBind();
        }

        protected void gvModificacionMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModificacionMedicos.EditIndex = -1;
            gvModificacionMedicos.PageIndex = e.NewPageIndex;
            CargarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificacionMedicos.EditIndex = e.NewEditIndex;
            CargarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificacionMedicos.EditIndex = -1;
            CargarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            medico = new Entidades.Medico();
            negocioMedico = new NegocioMedico(); 
            medico.Legajo = int.Parse(((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Legajo")).Text);
            medico.Nombre = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nombre")).Text;
            medico.Apellido = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Apellido")).Text;
            medico.DNI = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_DNI")).Text;
            medico.Sexo = ((RadioButtonList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("rbl_et_Sexo")).SelectedValue[0];
            medico.FechaNacimiento = DateTime.Parse(((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_FechaNacimiento")).Text);
            medico.Nacionalidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nacionalidad")).Text;
            medico.CodigoProvincia = int.Parse(((DropDownList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("ddl_et_Provincias")).SelectedValue);
            medico.Localidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Localidad")).Text;
            medico.Direccion = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Direccion")).Text;
            medico.Correo = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Correo")).Text;
            medico.Telefono = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Telefono")).Text.Trim();
            medico.CodigoEspecialidad = int.Parse(((DropDownList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("ddl_et_Especialidades")).SelectedValue);

            if (negocioMedico.ModificarMedico(medico))
            {
                lblMensaje.Text = "Médico modificado correctamente.";
                gvModificacionMedicos.EditIndex = -1;
                CargarMedicosTabla();
            }
            else
            {
                lblMensaje.Text = "Error al modificar el médico. Verifique los datos ingresados.";
            }
        }

        public void CargarDDL(DropDownList ddlP, DropDownList ddlE)
        {
             negocioMedico = new NegocioMedico();

            ddlP.DataSource = negocioMedico.readerProvincias();
            ddlP.DataTextField = "Descripcion_PR";
            ddlP.DataValueField = "CodProvincia_PR";
            ddlP.DataBind();
            ddlP.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            ddlE.DataSource = negocioMedico.readerEspecialidad();
            ddlE.DataTextField = "Descripcion_ES";
            ddlE.DataValueField = "CodEspecialidad_ES";
            ddlE.DataBind();
            ddlE.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void gvModificacionMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            negocioMedico = new NegocioMedico(); 
            Entidades.Medico medico = new Entidades.Medico();
            // Nos aseguramos de que es una fila de datos
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Verifico si la fila está en modo de edición
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //Encuentro los controles DropDownList dentro de la fila
                    DropDownList ddlProvincias = (DropDownList)e.Row.FindControl("ddl_et_Provincias");
                    DropDownList ddlEspecialidades = (DropDownList)e.Row.FindControl("ddl_et_Especialidades");

                    // Encuentro el control RadioButtonList para el sexo
                    RadioButtonList rblSexo = (RadioButtonList)e.Row.FindControl("rbl_et_Sexo");

                    //Llamo al metodo para cargar los datos en los DropDownList
                    CargarDDL(ddlProvincias, ddlEspecialidades);

                    //Selecciono la provincia y especialidad actual obteniendo los ID en la fila seleccionada.
                    string IDProvincia = DataBinder.Eval(e.Row.DataItem, "CodProvincia").ToString();
                    string IDEspecialidad = DataBinder.Eval(e.Row.DataItem, "CodEspecialidad").ToString();

                    // Selecciono el sexo del médico
                    char sexo = Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "Sexo").ToString()[0]);

                    // Encuentra el TextBox de la fecha de nacimiento
                    TextBox txtFechaNacimiento = (TextBox)e.Row.FindControl("txt_et_FechaNacimiento");


                    // Busco y selecciono los items en los DropDownList
                    ListItem itemProvincia = ddlProvincias.Items.FindByValue(IDProvincia.ToString());
                    if (itemProvincia != null)
                    {
                        ddlProvincias.SelectedValue = IDProvincia.ToString();
                    }

                    ListItem itemEspecialidad = ddlEspecialidades.Items.FindByValue(IDEspecialidad.ToString());
                    if (itemEspecialidad != null)
                    {
                        ddlEspecialidades.SelectedValue = IDEspecialidad.ToString();
                    }

                    if (itemProvincia == null && itemEspecialidad == null)
                    {
                        // Si no se encuentra se seleccionan los primeros items
                        ddlProvincias.SelectedIndex = 0;
                        ddlEspecialidades.SelectedIndex = 0;
                    }

                    // Selecciono el sexo del médico
                    if (sexo == 'M')
                    {
                        rblSexo.SelectedValue = "M";
                    }
                    else if (sexo == 'F')
                    {
                        rblSexo.SelectedValue = "F";
                    }
                    else
                    {
                        rblSexo.SelectedValue = null;
                    }

                    if (txtFechaNacimiento != null)
                    {
                        // Obtiene la fecha en formato string desde el DataItem
                        string fechaStr = DataBinder.Eval(e.Row.DataItem, "Fecha de Nacimiento").ToString();
                        DateTime fecha;
                        // Intenta parsear la fecha desde el formato dd/MM/yyyy
                        if (DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
                        {
                            // Asigna la fecha en formato yyyy-MM-dd (requerido por input type="date")
                            txtFechaNacimiento.Text = fecha.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            // Si falla el parseo, deja el campo vacío o maneja el error según tu lógica
                            txtFechaNacimiento.Text = "";
                        }
                    }

                }
            }
        }
    }
}
