<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaPaciente.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionPacientes.BajaPaciente" %>

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
        .auto-style9 {
            width: 1772px;
        }
        .auto-style7 {
            width: 926px;
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
                        <asp:HyperLink ID="hlAltaPaciente" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/AltaPaciente.aspx">Alta Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaPaciente" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/BajaPaciente.aspx">Baja Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionPaciente" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/ModificacionPaciente.aspx">Modificación Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarPacientes" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/ListarPacientes.aspx">Listar Pacientes</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td style="font-size: medium">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloBaja" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Baja de Paciente:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style9">
                <tr>
                    <td class="auto-style7">
                        DNI Paciente:&nbsp;<asp:TextBox ID="txtDNIBaja" runat="server"></asp:TextBox>
&nbsp;&nbsp; <asp:Button ID="btnBaja" runat="server" Text="Dar de Baja" Width="120px" OnClick="btnBaja_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <br />
                        <asp:Label ID="lblResultadoBaja" runat="server"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hlMenuGestionPacientes" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/MenuGestionPacientes.aspx">Regresar a Menú de Gestión de Pacientes...</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
