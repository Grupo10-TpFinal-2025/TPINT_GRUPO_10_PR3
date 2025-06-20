﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.AltaTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
            height: 100%;
            margin-bottom: 0px;
        }
        .auto-style6 {
            width: 1770px;
            height: 21px;
        }
        .auto-style3 {
            width: 1770px;
        }
        .auto-style5 {
            width: 1770px;
            height: 112px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style10 {
            height: 26px;
            width: 959px;
        }
        .auto-style12 {
            width: 883px;
        }
        .auto-style13 {
            width: 959px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlAltaTurno" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/BajaTurno.aspx">Baja Turno</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlBajaTurno" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModificacionTurno.aspx">Modificación Turno</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlModificacionTurno" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ListarTurnos.aspx">Listar Turno</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario:<asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;</td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTituloAltaTurno" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Alta de un Turno:"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style12">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6" style="font-size: medium; text-decoration: underline overline"></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp; Legajo:&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtLegajo" runat="server" Font-Size="Small" OnTextChanged="txtLegajo_TextChanged"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; DNI Paciente:
                        <asp:TextBox ID="txtDniPaciente" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mes:&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlMesFechaT" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="font-size: small; text-decoration: blink">
                        <asp:Button ID="btnAgregarT" runat="server" Text="Agregar Turno" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: underline overline; font-size: medium">
                        <asp:Label ID="lblResultadoAltaT" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9" style="text-decoration: blink; font-size: small">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" Font-Size="12pt" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar a Menú de Gestión de Turnos...</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">
                        <asp:Label ID="lblMensajeErrorLegajoT" runat="server"></asp:Label>
                        <asp:Label ID="lblMensajeErrorDniT" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
