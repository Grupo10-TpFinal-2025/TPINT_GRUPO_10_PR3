<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionTurno.aspx.cs" Inherits="Vistas.Administrador.SubMenu_GestionTurnos.ModificacionTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 881px;
        }
        .auto-style7 {
            width: 881px;
            height: 31px;
        }
        .auto-style8 {
            width: 1188px;
        }
        .auto-style9 {
            width: 881px;
            height: 23px;
        }
        .auto-style10 {
            width: 134%;
            height: 23px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style8">
                <tr>
                    <td class="auto-style2" style="font-size: large">
                        <asp:Panel ID="Panel1" runat="server">
                            <table class="auto-style10">
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hlAltaTurno" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/AltaTurno.aspx">Alta Turno</asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hlBajaTurno" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/BajaTurno.aspx">Baja Turno</asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ModificacionTurno.aspx">Modificación Turno</asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hlListarTurnos" runat="server" Font-Size="Large" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/ListarTurnos.aspx">Listar Turnos</asp:HyperLink>
                                    </td>
                                    <td>Usuario:
                                        <asp:Label ID="lblUsuarioAdministrador" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Modificación de Turno"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="gvModificarTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True">
    <Columns>
        <asp:TemplateField></asp:TemplateField>
        <asp:TemplateField HeaderText="ID Consulta">
            <ItemTemplate>
                <asp:Label ID="lbl_it_IDConsulta" runat="server" Text='<%# Eval("ID Consulta") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Medico">
            <ItemTemplate>
                <asp:Label ID="lbl_it_Medico" runat="server" Text='<%# Eval("Medico") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Paciente">
            <ItemTemplate>
                <asp:Label ID="lbl_it_Paciente" runat="server" Text='<%# Eval("Paciente") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Turno">
            <ItemTemplate>
                <asp:Label ID="lbl_it_Turno" runat="server" Text='<%# Eval("Turno") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pendiente">
            <ItemTemplate>
                <asp:CheckBox ID="chk_it_Pendiente" runat="server"
                    Checked='<%# Eval("Pendiente") != DBNull.Value && Convert.ToBoolean(Eval("Pendiente")) %>' 
                    Enabled="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Asistencia">
            <ItemTemplate>
                <asp:CheckBox ID="chk_it_Asistencia" runat="server"
                    Checked='<%# Eval("Asistencia") != DBNull.Value && Convert.ToBoolean(Eval("Asistencia")) %>' 
                    Enabled="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripcion">
            <ItemTemplate>
                <asp:Label ID="lbl_it_Descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:CheckBox ID="chk_it_Estado" runat="server"
                    Checked='<%# Eval("Estado") != DBNull.Value && Convert.ToBoolean(Eval("Estado")) %>' 
                    Enabled="false" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="lblModificacionMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hlGestionTurnos" runat="server" NavigateUrl="~/Administrador/SubMenu-GestionTurnos/MenuGestionTurnos.aspx">Regresar a  Menú de Gestión de Turnos...</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
