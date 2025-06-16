<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="Vistas.AltaMedico" %>

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
        .auto-style4 {
            width: 1770px;
            height: 34px;
        }
        .auto-style5 {
            width: 1770px;
            height: 112px;
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
                        <asp:HyperLink ID="hlAltaMedico" runat="server" Font-Size="Large" NavigateUrl="~/AltaMedico.aspx">Alta Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaMedico" runat="server" Font-Size="Large">Baja Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionMedico" runat="server" Font-Size="Large">Modificacion Medico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarMedicos" runat="server" Font-Size="Large">Listar Medicos</asp:HyperLink>
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
                        <asp:Label ID="lblTituloAltaMedico" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Alta de un Medico:"></asp:Label>
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
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp; DNI:&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtDniMedico" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Fecha Nacimiento:
                        <asp:TextBox ID="txtFechaNacimientoMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Nombre: <asp:TextBox ID="txtNombreMedico" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtApellidoMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="font-size: small; text-decoration: blink">Sexo: <asp:RadioButtonList ID="rblSexoMedico" runat="server" Font-Size="Small">
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
                        <asp:TextBox ID="NacionalidadMedico" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Provincia:
                        <asp:DropDownList ID="ddlProvinciaMedico" runat="server" Font-Size="Small">
                        </asp:DropDownList>
&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">&nbsp;&nbsp; Localidad:&nbsp;&nbsp;
                        <asp:TextBox ID="txtLocalidadMedico" runat="server" Font-Size="Small"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Direccion:
                        <asp:TextBox ID="DireccionMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: medium; text-decoration: underline overline">
                        <br />
                        DATOS DE CONTACTO:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Correo Electronico:
                        <asp:TextBox ID="txtCorreoMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTelefonoMedico" runat="server" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: underline overline; font-size: medium">
                        <br />
                        DATOS MEDICOS:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small">Especialidad:
                        <asp:DropDownList ID="ddlEspecialidadMedico" runat="server" Font-Size="Small">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRegistrarMedico" runat="server" Height="30px" OnClick="btnDisponivilidadMedico_Click" Text="Agregar" Width="100px" />
&nbsp;
                        <br />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlDisponibilidadRapida" runat="server" Visible="False">Cargar la Disponibilidad del Medico Dado de Alta</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MenuGestionMedicos.aspx">Regresar a Menú de Gestion Medicos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
