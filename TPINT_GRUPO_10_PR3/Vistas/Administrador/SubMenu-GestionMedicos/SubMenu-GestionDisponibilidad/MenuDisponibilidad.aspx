﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionDisponibilidad.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionDisponibilidad.MenuDisponibilidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Gestión de Disponibilidad</title>

<style type="text/css">
    body {
        background: linear-gradient(135deg, #f5f7fa, #c3cfe2);
        font-family: 'Segoe UI', Arial, sans-serif;
        color: #333;
        margin: 0;
        padding: 0;
    }

    .form-container {
        background: rgba(255, 255, 255, 0.95);
        border-radius: 10px;
        padding: 30px;
        max-width: 500px;
        margin: 40px auto;
        box-shadow: 0 6px 15px rgba(0, 0, 0, 0.1);
        text-align: center;
    }

    h1 {
        font-size: 24px;
        margin-bottom: 20px;
    }

    .btn-action {
        width: 260px; /* ancho cómodo para todas las palabras */
        padding: 10px;
        margin: 10px auto;
        background-color: #4CAF50;
        color: white;
        border: none;
        font-size: 16px;
        cursor: pointer;
        border-radius: 4px;
        display: block;
    }

    .btn-action:hover {
        background-color: #45a049;
    }

    .links-bar {
        text-align: center;
        margin-bottom: 15px;
    }

    .links-bar a {
        text-decoration: none;
        color: #333;
        margin: 0 15px;
        font-size: 14px;
    }

    .user-info {
        text-align: center;
        font-size: 14px;
        margin-bottom: 20px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">

            <div class="links-bar">
                <asp:HyperLink ID="hlMenuAdministrador" runat="server" NavigateUrl="~/Administrador/MenuAdministrador.aspx">Regresar a Menú Administrador</asp:HyperLink>
            </div>

            <div class="user-info">
                Usuario: <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
            </div>

            <h1>Gestión de Disponibilidad</h1>

            <asp:Button ID="btnAltaDisponibilidad" runat="server" Text="Alta Disponibilidad" CssClass="btn-action" OnClick="btnAltaDisponibilidad_Click" />

            <asp:Button ID="btnBajaDisponibilidad" runat="server" Text="Baja Disponibilidad" CssClass="btn-action" OnClick="btnBajaDisponibilidad_Click" />

            <asp:Button ID="btnModificacionDisponibilidad" runat="server" Text="Modificación Disponibilidad" CssClass="btn-action" OnClick="btnModificacionDisponibilidad_Click" />

            <asp:Button ID="btnListadoDisponibilidad" runat="server" Text="Listar Disponibilidades" CssClass="btn-action" OnClick="btnListarDisponibilidad_Click" />

        </div>
    </form>
</body>
</html>
