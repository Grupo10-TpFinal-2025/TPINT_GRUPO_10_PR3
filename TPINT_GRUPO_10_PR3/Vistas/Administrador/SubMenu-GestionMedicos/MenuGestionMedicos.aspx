﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionMedicos.aspx.cs" Inherits="Vistas.MenuGestionMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style7 {
            width: 32px;
        }
        .auto-style8 {
            width: 475px;
        }

        .auto-style2 {
            width: 33px;
        }
        .auto-style5 {
            width: 111px;
        }
        .auto-style3 {
            width: 33px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
            width: 111px;
        }
        .auto-style4 {
            height: 23px;
        }
        
    .boton-estandar {
        font-size: 14px;
    }

        .auto-style9 {
            width: 33px;
            height: 31px;
        }
        .auto-style10 {
            width: 111px;
            height: 31px;
        }
        .auto-style11 {
            height: 31px;
        }
        
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                    <asp:HyperLink ID="hlMenuAdministrador" runat="server" NavigateUrl="~/Administrador/MenuAdministrador.aspx">Regresar a Menú Administrador</asp:HyperLink>
                </td>
                <td>
                    Usuario:
                    <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="lblTituloGestionMedico" runat="server" Font-Bold="True" Font-Size="25pt" Text="Gestión de Registros de Médicos:"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style6"></td>
                <td class="auto-style4">
                    <asp:Button ID="btnAltaMedico" runat="server" Text="Alta Registro Médico" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnAltaMedico_Click" />
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnBajaMedico" runat="server" Text="Baja Registro Médico" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnBajaMedico_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:Button ID="btnModificacionMedico" runat="server" Text="Modificación Registro Médico" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnModificacionMedico_Click" />
                </td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnListadoMedicos" runat="server" Text="Listar Registros Médicos" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnListadoMedicos_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style6"></td>
                <td class="auto-style4">
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="btnGestionarDisponibilidadMedicos" runat="server" Text="Gestionar Disponibilidad" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnGestionarTurnosMedicos_Click"/>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
