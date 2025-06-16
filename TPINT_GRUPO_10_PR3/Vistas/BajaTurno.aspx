<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaTurno.aspx.cs" Inherits="Vistas.BajaTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style6 {
            width: 281px;
        }
        .auto-style7 {
            width: 362px;
        }
        .auto-style8 {
            width: 163px;
        }
        .auto-style9 {
            width: 926px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style9">
                <tr>
                    <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hpListarTurnos" runat="server">Listar Turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hpGestionTurnos" runat="server">Regresar Gestion Turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style8">Usuario:
                        <asp:Label ID="lblAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;&nbsp;
                        <asp:Label ID="lblBajaTurno" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cancelacion de Turno"></asp:Label>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">Código de turno:&nbsp; <asp:TextBox ID="txtCodigoTurno" runat="server" Width="108px"></asp:TextBox>
&nbsp;<asp:Button ID="btnCancelarTurno" runat="server" Text="Cancelar" Width="83px" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblResultadoBaja" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
