<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionPacientes.AltaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
                body {
        background: linear-gradient(135deg, #e0f7fa, #b3e5fc); /* degradado azul claro */
        font-family: 'Segoe UI', Arial, sans-serif; /* tipografía moderna */
        color: #333; /* texto gris oscuro */
        margin: 0;
        padding: 0;
             }


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
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
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
                        <asp:TextBox ID="txtDniPaciente" runat="server" Font-Size="Small" TextMode="Number"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDniPaciente" ErrorMessage="Debe ingresar un dni valido." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDniPaciente" ErrorMessage="Solo se permite el ingreso de números en el DNI." ValidationExpression="^\d{8}$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                        &nbsp;&nbsp;&nbsp; Fecha Nacimiento:
                        <asp:TextBox ID="txtFechaNacimientoPaciente" runat="server" Font-Size="Small" TextMode="Date"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvFeechaNacimiento" runat="server" ControlToValidate="txtFechaNacimientoPaciente" ErrorMessage="Ingrese una fecha." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Nombre: <asp:TextBox ID="txtNombrePaciente" runat="server" Font-Size="Small" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombrePaciente" ErrorMessage="Debe ingresar un nombre." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtApellidoPaciente" runat="server" Font-Size="Small" MaxLength="50"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellidoPaciente" ErrorMessage="Debe ingresar un apellido." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="font-size: small; text-decoration: blink">Sexo:  
                        <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="rblSexoPaciente" ErrorMessage="Debe indicar el sexo del medico." ValidationGroup="alta">*</asp:RequiredFieldValidator>
&nbsp;<asp:RadioButtonList ID="rblSexoPaciente" runat="server" Font-Size="Small">
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
                        <asp:TextBox ID="txtNacionalidadPaciente" runat="server" Font-Size="Small" MaxLength="50"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfvNacionaldiad" runat="server" ControlToValidate="txtNacionalidadPaciente" ErrorMessage="Debe ingresar una nacionalidad." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp; Provincia:
                        <asp:DropDownList ID="ddlProvinciaPaciente" runat="server" Font-Size="Small" OnSelectedIndexChanged="ddlProvinciaPaciente_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvinciaPaciente" ErrorMessage="Debe seleccionar una provincia." InitialValue="0" ValidationGroup="alta">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-decoration: blink; font-size: small">&nbsp;&nbsp; Localidad:&nbsp;&nbsp;
                        <asp:TextBox ID="txtLocalidadPaciente" runat="server" Font-Size="Small" MaxLength="50"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidadPaciente" ErrorMessage="Debe ingresar una localidad." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp; Dirección:
                        <asp:TextBox ID="txtDireccionPaciente" runat="server" Font-Size="Small" MaxLength="100"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccionPaciente" ErrorMessage="Ingrese la direccion." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revDireccion" runat="server" ControlToValidate="txtDireccionPaciente" ErrorMessage="Debe ingresar calle y numero." ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+ \d+$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: medium; text-decoration: underline overline">
                        <br />
                        DATOS DE CONTACTO:</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">Correo Electrónico:
                        <asp:TextBox ID="txtCorreoPaciente" runat="server" Font-Size="Small" TextMode="Email" MaxLength="100"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreoPaciente" ErrorMessage="Debe ingresar el correo electronico." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreoPaciente" ErrorMessage="Debe ingresar un correo electronico valido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="font-size: small; text-decoration: blink">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Teléfono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTelefonoPaciente" runat="server" Font-Size="Small" TextMode="Number"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefonoPaciente" ErrorMessage="Debe ingresar un numero de telefono." ValidationGroup="alta">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefonoPaciente" ErrorMessage="Solo se permiten numeros (10 maximo)." ValidationExpression="^\d{10}$" ValidationGroup="alta">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRegistrarPaciente" runat="server" Height="30px" Text="Agregar" Width="100px" OnClick="btnRegistrarPaciente_Click1" ValidationGroup="alta" />
&nbsp;
                        <asp:Button ID="btnAux" runat="server" OnClick="btnAux_Click1" Text="aux" Style="display:none;" UseSubmitBehavior="false"  />
                        <br />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:ValidationSummary ID="vsAltaMedico" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="alta" />
                    </td>
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
