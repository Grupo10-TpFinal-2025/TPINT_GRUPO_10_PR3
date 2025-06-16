<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionMedico.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionMedicos.ModificacionMedico" %>

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
        .auto-style8 {
            width: 23px;
            height: 23px;
        }
        .auto-style19 {
            width: 496px;
            height: 23px;
        }
        .auto-style17 {
            height: 23px;
            width: 212px;
        }
        .auto-style7 {
            width: 23px;
        }
        .auto-style18 {
            width: 496px;
        }
        .auto-style15 {
            width: 212px;
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
                        <asp:Label ID="lblTituloModificacionMedico" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Modificacion de Registros de Medicos:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">
                    <asp:ListView ID="lvModificacionMedico" runat="server" DataSourceID="SQLAccesoBD">
                    </asp:ListView>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">
                    <asp:SqlDataSource ID="SQLAccesoBD" runat="server"></asp:SqlDataSource>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style19">
                    &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style19">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MenuGestionMedicos.aspx">Regresar a Menú de Gestion Medicos...</asp:HyperLink>
                </td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style18">
                    &nbsp;</td>
                <td class="auto-style15">
                </td>
                <td class="auto-style15"></td>
            </tr>
        </table>
            <br />
        </div>
    </form>
</body>
</html>
