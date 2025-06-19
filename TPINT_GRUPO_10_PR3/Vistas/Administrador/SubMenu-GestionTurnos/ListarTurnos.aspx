<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarTurnos.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.ListarTurnos" %>

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
            width: 663px;
        }
        .auto-style3 {
            width: 275px;
        }
        .auto-style4 {
            width: 1658px;
            height: 23px;
        }
        .auto-style5 {
            width: 275px;
            height: 23px;
        }
        .auto-style6 {
            width: 663px;
            height: 30px;
        }
        .auto-style8 {
            width: 663px;
            height: 35px;
        }
        .auto-style9 {
            width: 1658px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlAltaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/AltaTurno.aspx">Alta Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlBajaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/BajaTurno.aspx">Baja Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlModificacionTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModificacionTurno.aspx">Modificación Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario:<asp:Label ID="lblAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Listar Turnos"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Código de turno: <asp:TextBox ID="txtListarTurno" runat="server" OnTextChanged="txtListarTurno_TextChanged" Width="135px"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btnFiltarTurno" runat="server" Text="Buscar" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:ListView ID="lvListarTurnos" runat="server">
                        </asp:ListView>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMostrarFiltrosAvanzado0" runat="server" Height="29px" OnClick="btnAplicarFiltroAvanzado0_Click" Text="Aplicar Filtros Avanzado" Width="234px" />
                    </td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Panel ID="panelListarTurnos" runat="server" Visible="False">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style6">Edad:
                                        <asp:DropDownList ID="ddlRangoEtario" runat="server" Height="20px" Width="120px">
                                            <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                            <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                            <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:TextBox ID="txtRangoEtario" runat="server" Width="105px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DNI:
                                        <asp:DropDownList ID="ddlDniPaciente" runat="server" Height="20px" Width="120px">
                                            <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                            <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                            <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:TextBox ID="txtDniPaciente" runat="server" Width="105px"></asp:TextBox>
                                        &nbsp;&nbsp; </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8">
                                        <asp:Label ID="lblResultadoFiltroAvanzado" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnAplicarFiltroAvanzado" runat="server" Height="27px" Text="Aplicar" Width="129px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnLimpiarFiltrosAvanzados" runat="server" Height="27px" Text="Limpiar Filtros" Width="129px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar a Menú de Gestión de Turnos...</asp:HyperLink>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
