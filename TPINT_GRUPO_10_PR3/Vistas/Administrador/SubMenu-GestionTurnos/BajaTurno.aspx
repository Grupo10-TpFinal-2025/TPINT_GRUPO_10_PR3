<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaTurno.aspx.cs" Inherits="Vistas.BajaTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style8 {
            width: 163px;
        }
        .auto-style9 {
            width: 926px;
        }
        .auto-style10 {
            width: 1427px;
        }
        .auto-style11 {
            width: 1427px;
            height: 23px;
        }
        .auto-style12 {
            width: 163px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style9">
                <tr>
                    <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlAltaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/AltaTurno.aspx">Alta Turno</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlModificacionTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModificacionTurno.aspx">Modificación Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hpListarTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ListarTurnos.aspx">Listar Turnos</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;&nbsp;
                        </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBajaTurno" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cancelación de Turno"></asp:Label>
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        Código de turno:&nbsp; <asp:TextBox ID="txtCodigoTurno" runat="server" Width="108px" TextMode="Number" ValidationGroup="BajaTurno"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtCodigoTurno" runat="server" ControlToValidate="txtCodigoTurno" Display="Dynamic" ErrorMessage="Debe ingresar un código de turno." ValidationGroup="BajaTurno">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnCancelarTurno" runat="server" Text="Cancelar" Width="83px" OnClick="btnCancelarTurno_Click" ValidationGroup="BajaTurno" />
                        <br />
                        <br />
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="lblResultadoBaja" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="BajaTurno" />
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar a Menú de Gestión de Turnos...</asp:HyperLink>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
