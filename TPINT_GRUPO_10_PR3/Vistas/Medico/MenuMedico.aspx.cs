﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"].ToString();
            }
        }

        protected void btnListarPacienteSeleccionado_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Medico/ListarPacientesSeleccionados.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx"); // Por si entra sin estar logueado
            }
        }

        protected void btnCambiarTurno_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Medico/CambioDeTurno.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx"); // Por si entra sin estar logueado
            }

        }
    }
}