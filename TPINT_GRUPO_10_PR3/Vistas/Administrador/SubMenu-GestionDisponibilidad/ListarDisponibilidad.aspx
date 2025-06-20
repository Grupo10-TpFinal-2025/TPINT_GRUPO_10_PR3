<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarDisponibilidad.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionDisponibilidad.ListarDisponibilidad" %>

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
        .auto-style8 {
            width: 23px;
            height: 23px;
        }
        .auto-style19 {
            width: 496px;
            height: 23px;
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
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="hlAltaDisponibilidad" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionDisponibilidad/AltaDisponibilidad.aspx">Alta Disponibilidad</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlBajaDisponibilidad" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionDisponibilidad/BajaDisponibilidad.aspx">Baja Disponibilidad</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlModificacionDisponibilidad" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionDisponibilidad/ModificacionDisponibilidad.aspx">Modificación Disponibilidad</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlListarDisponibilidad" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionDisponibilidad/ListarDisponibilidad.aspx">Listar Disponibilidad</asp:HyperLink>
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
                        <asp:Label ID="lblTituloListadoDisponibilidad" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Listado de Disponibilidad Médica:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19"></td>
            </tr>
            </table>
            <br />
            <br />
            Búsqueda por legajo de médico:
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
                        <asp:SqlDataSource ID="SQLdsAccesoDB" runat="server"></asp:SqlDataSource>
                        <asp:DataList ID="dlFiltroDiasDisponibilidad" runat="server" DataSourceID="SQLdsAccesoDB">
                        </asp:DataList>
                    </td>
                    <td>
                        <asp:ListView ID="lvListaroDisponibilidadM" runat="server">
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
                            <asp:Label ID="lblCantidadHoras" runat="server" Text="Rango Horario: "></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddOperatorsRangoHorario" runat="server" Height="20px" Width="105px">
                                <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtRangoHorario" runat="server" Width="54px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblEspecialidadMedico" runat="server" Text="Especialidad:"></asp:Label>
                            &nbsp;<asp:DropDownList ID="ddlOperatorsEspecialidad" runat="server" Height="20px" style="margin-bottom: 0px">
                                <asp:ListItem Value="contiene">Contiene:</asp:ListItem>
                                <asp:ListItem Value="empieza con">Empieza con:</asp:ListItem>
                                <asp:ListItem Value="termina con">Termina con:</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtEspecialidad" runat="server" Width="145px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAplicarFiltrosAvanzados" runat="server" Height="27px" Text="Aplicar" Width="103px" />
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
                        <td>
                            <asp:HyperLink ID="hlMenuGestionDisponibilidad" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionDisponibilidad/MenuDisponibilidad.aspx">Regresar a Menú de Gestión de Disponibilidad...</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
