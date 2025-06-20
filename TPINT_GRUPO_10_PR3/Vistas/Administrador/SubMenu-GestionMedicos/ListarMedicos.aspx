﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedicos.aspx.cs" Inherits="Vistas.ListarMedicos" %>

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
        .auto-style5 {
            width: 357px;
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
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td style="font-size: medium">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td style="font-size: medium">Usuario:
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True" EnableTheming="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloListarMedicos" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Listar Médicos:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            Búsqueda médico por legajo:
                                <asp:TextBox ID="txtFiltroLegajoMedico" runat="server" Width="162px" TextMode="Number"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnFiltrarMedicoLegajo" runat="server" Text="Filtrar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" />
                            &nbsp;&nbsp;
                                <asp:Label ID="lblLegajoNoEncontrado" runat="server"></asp:Label>
                            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:SqlDataSource ID="sqldsDias" runat="server" ConnectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=TPI-Grupo10;Integrated Security=True;Encrypt=False" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Descripcion_DI] FROM [Dia]"></asp:SqlDataSource>
                        <asp:DataList ID="dlFiltroDiasAtendidosM" runat="server" DataSourceID="sqldsDias">
                            <ItemTemplate>
                                <asp:Button ID="btnDia" runat="server" Text='<%# Eval("Descripcion_DI") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td class="auto-style5">
                        <asp:GridView ID="gvListaMedicos" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvListaMedicos_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <br />
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnMenuFiltrosAvanzados" runat="server" Height="29px" Text="Aplicar Filtros Avanzados" Width="234px" OnClick="btnMenuFiltrosAvanzados_Click" />
                        <br />
                        <br />
                        </td>
                    <td>&nbsp;</td>
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
                            &nbsp;<asp:TextBox ID="txtIDniMedico" runat="server" Width="54px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblApellidoMedico" runat="server" Text="Apellido:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsApellido" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="contiene">Contiene:</asp:ListItem>
                                <asp:ListItem Value="empieza con">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="termina con">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtApellidoMedico" runat="server" Width="145px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCorreoMedico" runat="server" Text="Correo:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsCorreo" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="contiene">Contiene:</asp:ListItem>
                                <asp:ListItem Value="empieza con">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="termina con">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtCorreoMedico" runat="server" Width="145px"></asp:TextBox>
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
                        <asp:HyperLink ID="hpRegresarMenuGestionMedicos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/MenuGestionMedicos.aspx">Regresar a Menú de Gestión de Médicos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
