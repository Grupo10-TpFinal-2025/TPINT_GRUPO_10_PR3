<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaTurno.aspx.cs" Inherits="Vistas.BajaTurno" %>

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
            width: 346px;
        }
        .auto-style3 {
            width: 294px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hpListarTurnos" runat="server">Listar Turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hpGestionTurnos" runat="server" NavigateUrl="~/MenuGestionTurnos.aspx">Regresar Gestion Turnos</asp:HyperLink>
                    </td>
                    <td>&nbsp;&nbsp; Usuario:
                        <asp:Label ID="lblAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBajaTurno" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cancelacion de Turno"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp; Código de turno:&nbsp;&nbsp;<asp:TextBox ID="txtCodigoTurno" runat="server" Width="108px"></asp:TextBox>
&nbsp;<asp:Button ID="btnCancelarTurno" runat="server" Text="Cancelar" Width="83px" />
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblResultadoBaja" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
