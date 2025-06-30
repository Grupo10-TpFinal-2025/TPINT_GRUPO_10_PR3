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
            font-size: x-large;
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
            font-size: x-large;
            height: 56px;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            width: 30px;
            height: 56px;
        }
        .auto-style13 {
            height: 56px;
        }
        .auto-style15 {
            width: 384px;
            height: 45px;
        }
        .auto-style16 {
            width: 30px;
            height: 45px;
        }
        .auto-style17 {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style8"></td>
                <td class="auto-style7">
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
                <td>&nbsp;</td>
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
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvUsuarioNuevo" runat="server" ControlToValidate="txtNuevoUsuario" ErrorMessage="Ingrese nombre de Usuario"></asp:RequiredFieldValidator>
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
                <td class="auto-style7"></td>
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
                <td class="auto-style17">
                    <asp:RegularExpressionValidator ID="revContraseña" runat="server" ControlToValidate="txtNuevaContraseña" ErrorMessage="La contraseña debe tener al menos una mayúscula, una minúscula, un número y un carácter especial." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).+$"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style10">Reingrese la contraseña:</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNuevaContraseña2" runat="server" Height="20px" Width="126px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
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
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAgregarUsuarioMedico" runat="server" Height="35px" Text="Agregar Usuario" Width="124px" OnClick="btnAgregarUsuarioMedico_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:Label ID="lblContraseña" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="auto-style11">
        </div>
    </form>
</body>
</html>
