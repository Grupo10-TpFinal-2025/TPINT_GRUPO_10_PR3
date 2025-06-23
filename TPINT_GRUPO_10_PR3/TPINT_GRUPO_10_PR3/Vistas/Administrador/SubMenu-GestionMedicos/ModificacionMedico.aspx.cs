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
            gvModificacionMedicos.EditIndex = e.NewEditIndex;
            CagarMedicosTabla();

        }

        protected void gvModificacionMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificacionMedicos.EditIndex = -1;
            CagarMedicosTabla();
        }

        protected void gvModificacionMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            medico = new Entidades.Medico();
            negocioMedico = new NegocioMedico(); 
            medico.Legajo = int.Parse(((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Legajo")).Text);
            medico.Nombre = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nombre")).Text;
            medico.Apellido = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Apellido")).Text;
            medico.DNI = ((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_DNI")).Text;
            medico.Sexo = ((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_Sexo")).Text[0];
            medico.FechaNacimiento = DateTime.Parse(((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_FechaNacimiento")).Text);
            medico.Nacionalidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Nacionalidad")).Text;
            medico.CodigoProvincia = int.Parse(((DropDownList)gvModificacionMedicos.Rows[e.RowIndex].FindControl("ddl_et_Provincias")).SelectedValue);
            medico.Localidad = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Localidad")).Text;
            medico.Direccion = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Direccion")).Text;
            medico.Correo = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Correo")).Text;
            medico.Telefono = ((TextBox)gvModificacionMedicos.Rows[e.RowIndex].FindControl("txt_et_Telefono")).Text.Trim();
            medico.CodigoEspecialidad = int.Parse(((Label)gvModificacionMedicos.Rows[e.RowIndex].FindControl("lbl_et_CodEspecialidad")).Text);

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
       public void ObtenerProvincias(DropDownList ddl)
        {
            negocioMedico = new NegocioMedico();

            ddl.DataSource = negocioMedico.readerProvincias();
            ddl.DataTextField = "Descripcion_PR";
            ddl.DataValueField = "CodProvincia_PR";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void gvModificacionMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            negocioMedico = new NegocioMedico(); 
            Entidades.Medico medico = new Entidades.Medico();
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
                            ddlProvincias.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
                            ddlProvincias.SelectedIndex = 0;
                        }
                    
                }
            }
        }
    }
}
