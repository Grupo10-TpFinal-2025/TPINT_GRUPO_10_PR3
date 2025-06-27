<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarTurnos.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.ListarTurnos" %>

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
            width: 663px;
        }
        .auto-style3 {
            width: 275px;
        }
        .auto-style4 {
            width: 1658px;
            height: 23px;
        }
        .auto-style5 {
            width: 275px;
            height: 23px;
        }
        .auto-style6 {
            width: 663px;
            height: 30px;
        }
        .auto-style8 {
            width: 663px;
            height: 35px;
        }
        .auto-style9 {
            width: 1658px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlAltaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/AltaTurno.aspx">Alta Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlBajaTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/BajaTurno.aspx">Baja Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlModificacionTurno" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModificacionTurno.aspx">Modificación Turno</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario:<asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Listar Turnos"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Código de turno: <asp:TextBox ID="txtListarTurno" runat="server" OnTextChanged="txtListarTurno_TextChanged" Width="135px"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btnFiltarTurno" runat="server" Text="Buscar" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:ListView ID="lvListarTurnos" runat="server" DataKeyNames="CodTurno_TU" DataSourceID="SqlDataSourceTurno">
                            <AlternatingItemTemplate>
                                <tr style="background-color:#FFF8DC;">
                                    <td>
                                        <asp:Label ID="CodTurno_TULabel" runat="server" Text='<%# Eval("CodTurno_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoMedico_TULabel" runat="server" Text='<%# Eval("LegajoMedico_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoPaciente_TULabel" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Fecha_TULabel" runat="server" Text='<%# Eval("Fecha_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Pendiente_TUCheckBox" runat="server" Checked='<%# Eval("Pendiente_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Asistencia_TUCheckBox" runat="server" Checked='<%# Eval("Asistencia_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Estado_TUCheckBox" runat="server" Checked='<%# Eval("Estado_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Descripcion_TULabel" runat="server" Text='<%# Eval("Descripcion_TU") %>' />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <EditItemTemplate>
                                <tr style="background-color:#008A8C;color: #FFFFFF;">
                                    <td>
                                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                    </td>
                                    <td>
                                        <asp:Label ID="CodTurno_TULabel1" runat="server" Text='<%# Eval("CodTurno_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LegajoMedico_TUTextBox" runat="server" Text='<%# Bind("LegajoMedico_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LegajoPaciente_TUTextBox" runat="server" Text='<%# Bind("LegajoPaciente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Fecha_TUTextBox" runat="server" Text='<%# Bind("Fecha_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Pendiente_TUCheckBox" runat="server" Checked='<%# Bind("Pendiente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Asistencia_TUCheckBox" runat="server" Checked='<%# Bind("Asistencia_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Estado_TUCheckBox" runat="server" Checked='<%# Bind("Estado_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Descripcion_TUTextBox" runat="server" Text='<%# Bind("Descripcion_TU") %>' />
                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <InsertItemTemplate>
                                <tr style="">
                                    <td>
                                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="LegajoMedico_TUTextBox" runat="server" Text='<%# Bind("LegajoMedico_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LegajoPaciente_TUTextBox" runat="server" Text='<%# Bind("LegajoPaciente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Fecha_TUTextBox" runat="server" Text='<%# Bind("Fecha_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Pendiente_TUCheckBox" runat="server" Checked='<%# Bind("Pendiente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Asistencia_TUCheckBox" runat="server" Checked='<%# Bind("Asistencia_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Estado_TUCheckBox" runat="server" Checked='<%# Bind("Estado_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Descripcion_TUTextBox" runat="server" Text='<%# Bind("Descripcion_TU") %>' />
                                    </td>
                                </tr>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <tr style="background-color:#DCDCDC;color: #000000;">
                                    <td>
                                        <asp:Label ID="CodTurno_TULabel" runat="server" Text='<%# Eval("CodTurno_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoMedico_TULabel" runat="server" Text='<%# Eval("LegajoMedico_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoPaciente_TULabel" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Fecha_TULabel" runat="server" Text='<%# Eval("Fecha_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Pendiente_TUCheckBox" runat="server" Checked='<%# Eval("Pendiente_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Asistencia_TUCheckBox" runat="server" Checked='<%# Eval("Asistencia_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Estado_TUCheckBox" runat="server" Checked='<%# Eval("Estado_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Descripcion_TULabel" runat="server" Text='<%# Eval("Descripcion_TU") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                                    <th runat="server">CodTurno_TU</th>
                                                    <th runat="server">LegajoMedico_TU</th>
                                                    <th runat="server">LegajoPaciente_TU</th>
                                                    <th runat="server">Fecha_TU</th>
                                                    <th runat="server">Pendiente_TU</th>
                                                    <th runat="server">Asistencia_TU</th>
                                                    <th runat="server">Estado_TU</th>
                                                    <th runat="server">Descripcion_TU</th>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                            <asp:DataPager ID="DataPager1" runat="server">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                                    <td>
                                        <asp:Label ID="CodTurno_TULabel" runat="server" Text='<%# Eval("CodTurno_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoMedico_TULabel" runat="server" Text='<%# Eval("LegajoMedico_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="LegajoPaciente_TULabel" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Fecha_TULabel" runat="server" Text='<%# Eval("Fecha_TU") %>' />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Pendiente_TUCheckBox" runat="server" Checked='<%# Eval("Pendiente_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Asistencia_TUCheckBox" runat="server" Checked='<%# Eval("Asistencia_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Estado_TUCheckBox" runat="server" Checked='<%# Eval("Estado_TU") %>' Enabled="false" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Descripcion_TULabel" runat="server" Text='<%# Eval("Descripcion_TU") %>' />
                                    </td>
                                </tr>
                            </SelectedItemTemplate>
                        </asp:ListView>
                        <asp:SqlDataSource ID="SqlDataSourceTurno" runat="server" ConnectionString="<%$ ConnectionStrings:TPI-Grupo10Conexion %>" SelectCommand="SELECT [CodTurno_TU], [LegajoMedico_TU], [LegajoPaciente_TU], [Fecha_TU], [Pendiente_TU], [Asistencia_TU], [Estado_TU], [Descripcion_TU] FROM [Turno]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMostrarFiltrosAvanzado0" runat="server" Height="29px" OnClick="btnAplicarFiltroAvanzado0_Click" Text="Aplicar Filtros Avanzado" Width="234px" />
                    </td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Panel ID="panelListarTurnos" runat="server" Visible="False">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style6">Edad:
                                        <asp:DropDownList ID="ddlRangoEtario" runat="server" Height="20px" Width="120px">
                                            <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                            <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                            <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:TextBox ID="txtRangoEtario" runat="server" Width="105px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DNI:
                                        <asp:DropDownList ID="ddlDniPaciente" runat="server" Height="20px" Width="120px">
                                            <asp:ListItem Value="igual a">Igual a:</asp:ListItem>
                                            <asp:ListItem Value="mayor a">Mayor a:</asp:ListItem>
                                            <asp:ListItem Value="menor a">Menor a:</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:TextBox ID="txtDniPaciente" runat="server" Width="105px"></asp:TextBox>
                                        &nbsp;&nbsp; </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8">
                                        <asp:Label ID="lblResultadoFiltroAvanzado" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnAplicarFiltroAvanzado" runat="server" Height="27px" Text="Aplicar" Width="129px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnLimpiarFiltrosAvanzados" runat="server" Height="27px" Text="Limpiar Filtros" Width="129px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar a Menú de Gestión de Turnos...</asp:HyperLink>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
