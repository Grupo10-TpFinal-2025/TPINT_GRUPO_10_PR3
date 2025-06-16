<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionTurnos.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.MenuGestionTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 32px;
        }
        .auto-style3 {
            width: 475px;
        }
        .auto-style4 {
            width: 33px;
        }
        .auto-style5 {
            width: 111px;
        }
        .auto-style6 {
            width: 1036px;
        }
        .boton-estandar {
            font-size: 14px;
        }
        .auto-style7 {
            width: 33px;
            height: 31px;
        }
        .auto-style8 {
            width: 111px;
            height: 31px;
        }
        .auto-style9 {
            width: 1036px;
            height: 31px;
        }
        .auto-style10 {
            height: 31px;
        }
        .auto-style15 {
            width: 33px;
            height: 23px;
        }
        .auto-style16 {
            width: 111px;
            height: 23px;
        }
        .auto-style17 {
            width: 1036px;
            height: 23px;
        }
        .auto-style18 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlMenuAdministrador" runat="server" NavigateUrl="~/MenuAdministrador.aspx">Regresar Menú Administrador</asp:HyperLink>
                    </td>
                    <td>Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblTituloGestionTurnos" runat="server" Font-Bold="True" Font-Size="25pt" Text="Gestión de Turnos Médicos:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="btnAltaTurno" runat="server" CssClass="boton-estandar" Height="30px" Text="Alta Turno Médico" Width="200px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17">
                        <asp:Button ID="btnBajaTurno" runat="server" CssClass="boton-estandar" Height="30px" Text="Baja Turno Médico" Width="200px" />
                    </td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17">
                        <asp:Button ID="btnModificacionTurno" runat="server" CssClass="boton-estandar" Height="30px" Text="Modificación Turno Médico" Width="200px" OnClick="btnModificacionTurno_Click" />
                    </td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17">
                        <asp:Button ID="btnListadoTurno" runat="server" CssClass="boton-estandar" Height="30px" Text="Listar Turnos Médicos" Width="200px" />
                    </td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style18"></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
