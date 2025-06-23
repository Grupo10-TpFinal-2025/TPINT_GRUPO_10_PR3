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
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td style="font-size: medium">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td style="font-size: medium">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
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
                            &nbsp;<asp:Button ID="btnFiltrarPacienteDNI" runat="server" Text="Filtrar" OnClick="btnFiltrarPacienteDNI_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnMostrarTodosPacientes" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodosPacientes_Click" />
                            &nbsp;&nbsp;
                                <asp:Label ID="lblDNInoEncontrado" runat="server"></asp:Label>
                            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:GridView ID="gvProvincias" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnProvincia" runat="server" CommandArgument='<%# Bind("CodProvincia_PR") %>' CommandName="FiltroProvincias" OnCommand="btnProvincia_Command1" Text='<%# Bind("Descripcion_PR") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <asp:GridView ID="gvListadoPacientes" runat="server" OnPageIndexChanging="gvListadoPacientes_PageIndexChanging">
                        </asp:GridView>
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
                            &nbsp;<asp:DropDownList ID="ddlOperatorsDni" runat="server" Height="20px" Width="105px">
                                <asp:ListItem Value="1">Igual a:</asp:ListItem>
                                <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                                <asp:ListItem Value="3">Menor a:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtDniPaciente" runat="server" Width="140px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNombrePaciente" runat="server" Text="Nombre:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsNombre" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="1">Contiene:</asp:ListItem>
                                <asp:ListItem Value="2">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="3">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtNombrePaciente" runat="server" Width="145px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCorreoMedico" runat="server" Text="Teléfono:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsTelefono" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="1">Contiene:</asp:ListItem>
                                <asp:ListItem Value="2">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="3">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtTelefonoPaciente" runat="server" Width="145px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAplicarFiltrosAvanzados" runat="server" Height="27px" Text="Aplicar" Width="103px" OnClick="btnAplicarFiltrosAvanzados_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnLimpiarFiltrosPacientes" runat="server" Height="27px" Text="Limpiar Filtros" Width="129px" OnClick="btnLimpiarFiltrosPacientes_Click" />
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
                        <asp:HyperLink ID="hlMenuGestionPacientes" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionPacientes/MenuGestionPacientes.aspx">Regresar a Menú de Gestión de Pacientes...</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
        </div>
    </form>
</body>
</html>
