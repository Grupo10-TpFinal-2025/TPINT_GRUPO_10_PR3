<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPacientes.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionPacientes.ListarPacientes" %>

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
            width: 100%;
            height: 100%;
        }
        .auto-style4 {
            width: 281px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                        <asp:HyperLink ID="hlAltaMedico" runat="server" Font-Size="Large">Alta Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaMedico" runat="server" Font-Size="Large">Baja Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionMedico" runat="server" Font-Size="Large">Modificacion Paciente</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarMedicos" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/ListarPacientes.aspx">Listar Pacientes</asp:HyperLink>
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
                        <asp:Label ID="lblTituloListarPaciente" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Listar Pacientes:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            Búsqueda por DNI del paciente: <asp:TextBox ID="txtFiltroDNIPaciente" runat="server" Width="162px" TextMode="Number"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnFiltrarPAcienteDNI" runat="server" Text="Filtrar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnMostrarTodosPacientes" runat="server" Text="Mostrar Todos" />
                            &nbsp;&nbsp;
                                <asp:Label ID="lblDNInoEncontrado" runat="server"></asp:Label>
                            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:DataList ID="dlFiltroRangoEtarioPaciente" runat="server">
                        </asp:DataList>
                    </td>
                    <td>
                        <asp:ListView ID="lvListarPacientes" runat="server">
                        </asp:ListView>
                        <br />
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnMenuFiltrosAvanzados" runat="server" Height="29px" Text="Aplicar Filtros Avanzados" Width="234px" OnClick="btnMenuFiltrosAvanzados_Click" />
                        <br />
                        <br />
                        </td>
                </tr>
            </table>
            <asp:Panel ID="pnlFiltrosAvanzados" runat="server" Visible="False">
                <table class="auto-style1">
                    <tr>
                        <td>
                            <br />
                            <asp:Label ID="lblDniMedico" runat="server" Text="DNI: "></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddOperatorsDni" runat="server" Height="20px" Width="105px">
                                <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtIDniPaciente" runat="server" Width="54px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsNombre" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="contiene">Contiene:</asp:ListItem>
                                <asp:ListItem Value="empieza con">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="termina con">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtNombrePaciente" runat="server" Width="145px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCorreoMedico" runat="server" Text="Telefono:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsTelefono" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="contiene">Contiene:</asp:ListItem>
                                <asp:ListItem Value="empieza con">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="termina con">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtTelefonoPaciente" runat="server" Width="145px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAplicarFiltrosAvanzados" runat="server" Height="27px" Text="Aplicar" Width="103px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnLimpiarFiltrosMedicos" runat="server" Height="27px" Text="Limpiar Filtros" Width="129px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;<asp:Label ID="lblFiltrosAvanzadosVacios" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <table class="auto-style3">
                <tr>
                    <td>
                        <asp:HyperLink ID="hpRegresarMenuGestionMedicos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/MenuGestionMedicos.aspx">Regresar  Menú Gestion Medicos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        </div>
    </form>
</body>
</html>
