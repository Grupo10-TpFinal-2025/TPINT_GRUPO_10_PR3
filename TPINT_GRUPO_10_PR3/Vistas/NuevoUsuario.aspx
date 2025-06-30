<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="Vistas.NuevoUsuario" %>

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
            width: 361px;
        }
        .auto-style4 {
            width: 361px;
            font-size: large;
        }
        .auto-style5 {
            width: 30px;
            height: 23px;
        }
        .auto-style6 {
            width: 361px;
            height: 23px;
            font-size: x-large;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            width: 361px;
            height: 23px;
        }
        .auto-style9 {
            font-size: x-large;
        }
        .auto-style10 {
            width: 361px;
            font-size: x-large;
        }
        .auto-style11 {
            text-align: center;
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
                    <asp:TextBox ID="txtNuevoUsuario" runat="server" Height="20px" Width="126px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
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
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNuevaContraseña" runat="server" Height="20px" Width="126px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10">Reingrese la contraseña:</td>
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
                    <asp:TextBox ID="txtNuevaContraseña2" runat="server" Height="20px" Width="126px"></asp:TextBox>
                </td>
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
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAgregarUsuarioMedico" runat="server" Height="35px" Text="Agregar Usuario" Width="124px" />
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
