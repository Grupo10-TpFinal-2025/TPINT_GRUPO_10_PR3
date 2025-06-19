<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionPacientes.AltaPaciente" %>

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
        .auto-style3 {
            width: 1770px;
        }
        .auto-style5 {
            width: 1770px;
            height: 112px;
        }
        .auto-style4 {
            width: 1770px;
            height: 34px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
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
                        <asp:HyperLink ID="hlListarPacientes" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/ModificacionPaciente.aspx">Listar Pacientes</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td style="font-size: medium">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloAltaPaciente" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Alta de un Paciente:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" style="font-size: medium; text-decoration: underline overline">DATOS PERSONALES:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp; DNI:&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtDniPaciente" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Fecha Nacimiento:
                        <asp:TextBox ID="txtFechaNacimientoPaciente" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Nombre: <asp:TextBox ID="txtNombrePaciente" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtApellidoPaciente" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="font-size: small; text-decoration: blink">Sexo: <asp:RadioButtonList ID="rblSexoPaciente" runat="server" Font-Size="Small">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: underline overline; font-size: medium">DATOS DE VIVIENDA:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">Nacionalidad:
                        <asp:TextBox ID="NacionalidadPaciente" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Provincia:
                        <asp:DropDownList ID="ddlProvinciaPaciente" runat="server" Font-Size="Small">
                        </asp:DropDownList>
&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">&nbsp;&nbsp; Localidad:&nbsp;&nbsp;
                        <asp:TextBox ID="txtLocalidadPaciente" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dirección:
                        <asp:TextBox ID="DireccionPaciente" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: medium; text-decoration: underline overline">
                        <br />
                        DATOS DE CONTACTO:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Correo Electrónico:
                        <asp:TextBox ID="txtCorreoPaciente" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Teléfono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTelefonoMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRegistrarPaciente" runat="server" Height="30px" Text="Agregar" Width="100px" />
&nbsp;
                        <br />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlMenuGestionPacientes" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/MenuGestionPacientes.aspx">Regresar a Menú de Gestión de Pacientes...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
    </body>
</html>
