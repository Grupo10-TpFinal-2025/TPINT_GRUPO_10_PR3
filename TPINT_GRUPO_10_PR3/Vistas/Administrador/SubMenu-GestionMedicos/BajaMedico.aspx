<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaMedico.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionMedicos.BajaMedico" %>

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
        .auto-style2 {
            width: 853px;
        }
        .auto-style7 {
            width: 926px;
        }
        .auto-style9 {
            width: 1772px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="hlAltaMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/AltaMedico.aspx">Alta Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/BajaMedico.aspx">Baja Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/ModificacionMedico.aspx">Modificacion Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarMedicos" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/ListarMedicos.aspx">Listar Medicos</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td style="font-size: medium">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td style="font-size: medium">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloBajaMedico" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Baja de Medico:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style9">
                <tr>
                    <td class="auto-style7">
                        <br />
                        Legajo del Medico:&nbsp;<asp:TextBox ID="txtLejajoBajaMedico" runat="server"></asp:TextBox>
&nbsp;&nbsp; <asp:Button ID="btnBajaMedico" runat="server" Text="Dar de Baja" Width="107px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <br />
                        <asp:Label ID="lblResultadoBajaMedico" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hpRegresarMenuGestionMedicos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/MenuGestionMedicos.aspx">Regresar Menú Gestion Medicos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
