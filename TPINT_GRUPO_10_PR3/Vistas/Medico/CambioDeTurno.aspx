<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioDeTurno.aspx.cs" Inherits="Vistas.Medico.CambioDeTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1300px;
        }
        .auto-style4 {
            width: 259px;
            height: 23px;
        }
        .auto-style5 {
            width: 260px;
            height: 23px;
        }
        .auto-style7 {
            width: 23px;
        }
        .auto-style8 {
            width: 23px;
            height: 23px;
        }
        .auto-style15 {
            width: 212px;
        }
        .auto-style17 {
            height: 23px;
            width: 212px;
        }
        .auto-style18 {
            width: 496px;
        }
        .auto-style19 {
            width: 496px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <asp:HyperLink ID="hpCerrarSesion" runat="server" NavigateUrl="~/Login.aspx">Cerrar sesión</asp:HyperLink>
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style5">
                        <asp:HyperLink ID="hpMenuMedico" runat="server" NavigateUrl="~/Medico/MenuMedico.aspx">Volver al menú</asp:HyperLink>
                    </td>
                    <td class="auto-style5"></td>
                    <td class="auto-style5">Usuario:<asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style18">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="25pt" Text="Modificación de turno"></asp:Label>
                </td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15">LegajoMedico_TU, LegajoPaciente_TU, Fecha_TU, Pendiente_TU, Asistencia_TU, Descripcion_TU, Estado_TU</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style19">
                    <br />
                    <asp:GridView ID="gvActualizacionTurnos" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" ValidationGroup="Modificacion"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legajo Paciente">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_legajoPaciente" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_legajoPaciente" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_et_legajoPaciente" runat="server" Text='<%# Eval("LegajoPaciente_TU") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Eval("Fecha_TU") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Legajo Paciente" />
                            <asp:BoundField HeaderText="Asistencia" />
                            <asp:BoundField HeaderText="Descripcion" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            </table>
    </form>
</body>
</html>
