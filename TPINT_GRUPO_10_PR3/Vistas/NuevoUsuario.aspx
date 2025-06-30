<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NuevoUsuario.aspx.cs" Inherits="Vistas.NuevoUsuario" UnobtrusiveValidationMode="None" %>

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
            width: 30px;
        }
        .auto-style3 {
            width: 384px;
        }
        .auto-style4 {
            width: 384px;
            font-size: large;
        }
        .auto-style5 {
            width: 30px;
            height: 23px;
        }
        .auto-style6 {
            width: 384px;
            height: 23px;
            font-size: large;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            width: 384px;
            height: 23px;
        }
        .auto-style9 {
            font-size: x-large;
        }
        .auto-style10 {
            width: 384px;
            font-size: large;
            height: 35px;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style15 {
            width: 384px;
            height: 43px;
        }
        .auto-style16 {
            width: 30px;
            height: 43px;
        }
        .auto-style17 {
            height: 43px;
        }
        .auto-style18 {
            height: 23px;
            width: 1040px;
        }
        .auto-style19 {
            width: 1040px;
        }
        .auto-style20 {
            height: 43px;
            width: 1040px;
        }
        .auto-style21 {
            width: 30px;
            height: 35px;
        }
        .auto-style22 {
            height: 35px;
            width: 1040px;
        }
        .auto-style24 {
            width: 475px;
        }
        .auto-style25 {
            width: 29px;
        }
        .auto-style26 {
            width: 193px;
        }
        .auto-style27 {
            width: 193px;
            font-size: large;
            height: 37px;
        }
        .auto-style28 {
            height: 37px;
        }
        .auto-style29 {
            text-align: left;
        }
        .auto-style30 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style8"></td>
                <td class="auto-style18">
                    <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Login.aspx">Volver al Login</asp:HyperLink>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4"><span class="auto-style9">Ingrese el nuevo </span><strong><span class="auto-style9">usuario médico</span></strong>:</td>
                <td class="auto-style19">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNuevoUsuario" runat="server" Height="20px" Width="126px" MaxLength="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsuarioNuevo" runat="server" ControlToValidate="txtNuevoUsuario" ErrorMessage="Ingrese nombre de Usuario"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style19">
                    <asp:RegularExpressionValidator ID="revNuevoUsuario" runat="server" ControlToValidate="txtNuevoUsuario" ErrorMessage="No ingrese espacios en blanco" ValidationExpression="^\S+$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">Ingrese la contraseña:</td>
                <td class="auto-style18"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtNuevaContraseña" runat="server" Height="20px" Width="126px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtNuevaContraseña" ErrorMessage="Ingrese una contraseña"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style20">
                    <asp:RegularExpressionValidator ID="revContraseña" runat="server" ControlToValidate="txtNuevaContraseña" ErrorMessage="La contraseña debe tener al menos una mayúscula, una minúscula, un número y un carácter especial y NO contener espacios en blanco." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d])[^\s]+$"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style10">Reingrese la contraseña:</td>
                <td class="auto-style22"></td>
                <td class="auto-style30"></td>
                <td class="auto-style30"></td>
                <td class="auto-style30"></td>
                <td class="auto-style30"></td>
                <td class="auto-style30"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNuevaContraseña2" runat="server" Height="20px" Width="126px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContraseña2" runat="server" ControlToValidate="txtNuevaContraseña2" ErrorMessage="Debe ingresar algún valor"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style19">
                    <asp:CompareValidator ID="cvContraseñas" runat="server" ControlToCompare="txtNuevaContraseña" ControlToValidate="txtNuevaContraseña2" EnableClientScript="False" ErrorMessage="Las contreñas deben coincidir"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style27">Ingrese el Legajo médico:</td>
                            <td class="auto-style28"></td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:TextBox ID="txtLegajoMedico" runat="server" Height="27px" TextMode="Number" Width="59px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ErrorMessage="Ingrese un legajo" ControlToValidate="txtLegajoMedico"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style19">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="auto-style11">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style24">
                                <asp:Button ID="btnAgregarUsuarioMedico" runat="server" Height="35px" Text="Agregar Usuario" Width="124px" OnClick="btnAgregarUsuarioMedico_Click" />
                            </td>
                    <td class="auto-style29">
                    <asp:Label ID="lblContraseña" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
