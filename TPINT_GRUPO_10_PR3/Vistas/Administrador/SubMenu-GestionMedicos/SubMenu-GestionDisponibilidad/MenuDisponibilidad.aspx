﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionDisponibilidad.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionDisponibilidad.MenuDisponibilidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        .auto-style12 {
            width: 33px;
            height: 24px;
        }
        .auto-style13 {
            width: 111px;
            height: 24px;
        }
        .auto-style14 {
            height: 24px;
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
                    <asp:Label ID="lblTituloGestionDisponibilidad" runat="server" Font-Bold="True" Font-Size="25pt" Text="Gestión de Disponibilidad:"></asp:Label>
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
                    <asp:Button ID="btnAltaDisponibilidad" runat="server" Text="Alta Disponibilidad" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnAltaDisponibilidad_Click" />
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnBajaDisponibilidad" runat="server" Text="Baja Disponibilidad" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnBajaDisponibilidad_Click" />
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
                    <asp:Button ID="btnModificacionDisponibilidad" runat="server" Text="Modificación Disponibilidad" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnModificacionDisponibilidad_Click" />
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
                    <asp:Button ID="btnListadoDisponibilidad" runat="server" Text="Listar Disponibilidades" CssClass="boton-estandar" Height="30px" Width="200px" OnClick="btnListarDisponibilidad_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
