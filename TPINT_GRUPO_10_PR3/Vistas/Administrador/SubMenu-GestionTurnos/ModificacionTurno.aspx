<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionTurno.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.ModificacionTurno" %>

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
            width: 516px;
        }
        .auto-style5 {
            width: 219px;
        }
        .auto-style6 {
            width: 290px;
        }
        .auto-style7 {
            width: 516px;
            height: 31px;
        }
        .auto-style8 {
            width: 219px;
            height: 31px;
        }
        .auto-style9 {
            width: 290px;
            height: 31px;
        }
        .auto-style10 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" style="font-size: large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:HyperLink ID="hlAltaTurno" runat="server">Alta Turno</asp:HyperLink>
                        &nbsp;</td>
                    <td class="auto-style5" style="font-size: large">
                        <asp:HyperLink ID="hlBajaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/BajaTurno.aspx">Baja Turno</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style6" style="font-size: large">
                        <asp:HyperLink ID="hlListarTurnos0" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModicacionTuno.aspx">Modificacion Turno</asp:HyperLink>
                    </td>
                    <td style="font-size: large">
                        <asp:HyperLink ID="hlListarTurnos" runat="server">Listar Turnos</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario: <asp:Label ID="lblAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Modificación de Turno"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListView ID="lvModificacionTurnos" runat="server">
                        </asp:ListView>
                        <asp:SqlDataSource ID="dsTurnos" runat="server"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblModificacionMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar Menú Gestión Turnos...</asp:HyperLink>
                    </td>
                    <td class="auto-style8"></td>
                    <td class="auto-style9"> </td>
                    <td class="auto-style10"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
