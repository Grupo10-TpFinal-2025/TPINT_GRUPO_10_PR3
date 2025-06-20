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
        .auto-style6 {
            width: 1770px;
            height: 26px;
        }
        .auto-style7 {
            width: 1770px;
            height: 29px;
        }
        .auto-style8 {
            width: 853px;
            height: 29px;
        }
        .auto-style9 {
            height: 29px;
        }
        .auto-style10 {
            width: 1770px;
            height: 42px;
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
                        <asp:HyperLink ID="hlAltaMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/AltaMedico.aspx">Alta Médico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/BajaMedico.aspx">Baja Médico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionMedico" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/ModificacionMedico.aspx">Modificación Médico</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarMedicos" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/ListarMedicos.aspx">Listar Médicos</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td style="font-size: medium" class="auto-style9">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True" Text="Administrador"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloAltaMedico" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Alta de un Médico:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6" style="font-size: medium; text-decoration: underline overline">DATOS PERSONALES:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp; DNI:&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="txtDniMedico" runat="server" Font-Size="Small" TextMode="Number" ValidationGroup="alta"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDniMedico" ErrorMessage="Debe ingresar un dni valido." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDniMedico" ErrorMessage="Solo se permite el ingreso de numeros en el DNI." ValidationExpression="^\d+$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                        &nbsp;&nbsp; Fecha Nacimiento:
                        <asp:TextBox ID="txtFechaNacimientoMedico" runat="server" Font-Size="Small" TextMode="Date" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFeechaNacimiento" runat="server" ControlToValidate="txtFechaNacimientoMedico" ErrorMessage="Ingrese una fecha." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" style="font-size: small; text-decoration: blink">Nombre: <asp:TextBox ID="txtNombreMedico" runat="server" Font-Size="Small" ValidationGroup="alta"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombreMedico" ErrorMessage="Debe ingresar un nombre." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtApellidoMedico" runat="server" Font-Size="Small" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellidoMedico" ErrorMessage="Debe ingresar un apellido." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="font-size: small; text-decoration: blink">Sexo: 
                        <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="rblSexoMedico" ErrorMessage="Debe indicar el sexo del medico." ValidationGroup="alta">*</asp:RequiredFieldValidator>
&nbsp;<asp:RadioButtonList ID="rblSexoMedico" runat="server" Font-Size="Small" ValidationGroup="alta">
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
                        <asp:TextBox ID="txtNacionalidadMedico" runat="server" Font-Size="Small" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNacionaldiad" runat="server" ControlToValidate="txtNacionalidadMedico" ErrorMessage="Debe ingresar una nacionalidad." ValidationGroup="alta">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Provincia:
                        <asp:DropDownList ID="ddlProvinciaMedico" runat="server" Font-Size="Small" Height="17px" ValidationGroup="alta" Width="126px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaMedico_SelectedIndexChanged">
                        </asp:DropDownList>
&nbsp; 
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvinciaMedico" ErrorMessage="Debe seleccionar una provincia." InitialValue="0" ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">&nbsp;&nbsp; Localidad:&nbsp;&nbsp;
                        <asp:TextBox ID="txtLocalidadMedico" runat="server" Font-Size="Small" ValidationGroup="alta"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidadMedico" ErrorMessage="Debe ingresar una localidad." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp; Dirección:
                        <asp:TextBox ID="txtDireccionMedico" runat="server" Font-Size="Small" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccionMedico" ErrorMessage="Ingrese la direccion." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDireccion" runat="server" ControlToValidate="txtDireccionMedico" ErrorMessage="Debe ingresar calle y numero." ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+ \d+$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10" style="font-size: medium; text-decoration: underline overline">
                        <br />
                        DATOS DE CONTACTO:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Correo Electrónico:
                        <asp:TextBox ID="txtCorreoMedico" runat="server" Font-Size="Small" TextMode="Email" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreoMedico" ErrorMessage="Debe ingresar el correo electronico." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreoMedico" ErrorMessage="Debe ingresar un correo electronico valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Teléfono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTelefonoMedico" runat="server" Font-Size="Small" TextMode="Number" ValidationGroup="alta"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefonoMedico" ErrorMessage="Debe ingresar un numero de telefono." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefonoMedico" ErrorMessage="Solo se permiten numeros (10 maximo)." ValidationExpression="^\d{1,10}$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10" style="text-decoration: underline overline; font-size: medium">
                        <br />
                        DATOS MEDICOS:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small">Especialidad:
                        <asp:DropDownList ID="ddlEspecialidadMedico" runat="server" Font-Size="Small" Height="16px" ValidationGroup="alta" Width="137px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidadMedico_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidadMedico" ErrorMessage="Debe seleccionar una especialdiad." InitialValue="0" ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRegistrarMedico" runat="server" Height="30px" OnClick="btnDisponivilidadMedico_Click" Text="Agregar" Width="100px" ValidationGroup="alta" />
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
                        <asp:HyperLink ID="hlDisponibilidadRapida" runat="server" Visible="False">Cargar la Disponibilidad del Médico Dado de Alta</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/MenuGestionMedicos.aspx">Regresar a Menú de Gestión de Médicos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <asp:ValidationSummary ID="vsAltaMedico" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="alta" />
            <br />
        </div>
    </form>
</body>
</html>
