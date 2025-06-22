<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionMedico.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionMedicos.ModificacionMedico" %>

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
        .auto-style17 {
            height: 23px;
            width: 212px;
        }
        .auto-style7 {
            width: 23px;
        }
        .auto-style18 {
            width: 496px;
        }
        .auto-style15 {
            width: 212px;
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
                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTituloModificacionMedico" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Modificación de Registros de Médicos:"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">
                    <asp:GridView ID="gvModificacionMedicos" runat="server" AllowPaging="True" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvModificacionMedicos_PageIndexChanging" OnRowCancelingEdit="gvModificacionMedicos_RowCancelingEdit" OnRowEditing="gvModificacionMedicos_RowEditing" OnRowUpdating="gvModificacionMedicos_RowUpdating" PageSize="5" OnRowDataBound="gvModificacionMedicos_RowDataBound" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Legajo">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_Legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                                    <br />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Nombre" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Apellido" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sexo">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Nacimiento">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_FechaNacimiento" runat="server" Text='<%# Bind("Nacimiento") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Bind("Nacimiento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nacionalidad">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Nacionalidad" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Provincia">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_et_Provincias" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Localidad">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Localidad" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Direccion" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telefono">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Telefono" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_et_Correo" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Especialidad">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                                    <asp:Label ID="lbl_et_CodEspecialidad" runat="server" Text='<%# Bind("CodEspecialidad") %>' Visible="False"></asp:Label>
                                </EditItemTemplate>
                                    <ItemTemplate>
                                    <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">
                    &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style19">
                    &nbsp;</td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style19">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionMedicos/MenuGestionMedicos.aspx">Regresar a Menú de Gestión de Médicos...</asp:HyperLink>
                </td>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style18">
                    &nbsp;</td>
                <td class="auto-style15">
                </td>
                <td class="auto-style15"></td>
            </tr>
        </table>
            <br />
        </div>
    </form>
</body>
</html>
