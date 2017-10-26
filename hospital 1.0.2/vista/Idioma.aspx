<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MasterAdminVic.master" AutoEventWireup="true" CodeFile="~/logica/Idioma.aspx.cs" Inherits="vista_Idioma" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style9 {
            width: 100%;
            height: 187px;
        }
        .auto-style10 {
        }
        .auto-style11 {
            height: 148px;
        }
        .auto-style12 {
            width: 211px;
            height: 148px;
        }
        .auto-style13 {
            height: 20px;
        }
        .auto-style14 {
            height: 40px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style9">
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style12">
                <asp:GridView ID="GV_Idiomas" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataSourceID="ObjectDataSource1">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="buscaidioma" TypeName="Logica.Lparametriza"></asp:ObjectDataSource>
            </td>
            <td class="auto-style11" colspan="2">
                <asp:Label ID="L_Idioma" runat="server" Text="Idioma"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Idioma" runat="server" MaxLength="10"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFV_Idioma" runat="server" ControlToValidate="TB_Idioma" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Idioma" runat="server" ControlToValidate="TB_Idioma" Display="Dynamic" ErrorMessage="Solo letras" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ñÑáéíóúÁÉÍÓÚ ]+$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style11">
                <asp:Label ID="L_Terminacion" runat="server" Text="Terminacion"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Terminacion" runat="server" MaxLength="10"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFV_Terminacion" runat="server" ControlToValidate="TB_Terminacion" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Terminacion" runat="server" ControlToValidate="TB_Terminacion" Display="Dynamic" ErrorMessage="Solo letras" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ñÑáéíóúÁÉÍÓÚ ]+$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style13" colspan="2"></td>
            <td class="auto-style13" colspan="2">
                <asp:Button ID="B_AgregarIdioma" runat="server" CssClass="btn-danger active" Text="Agregar Idioma" OnClick="Button1_Click" ValidationGroup="1" />
            </td>
            <td class="auto-style13"></td>
        </tr>
        <tr>
            <td class="auto-style14"></td>
            <td> <asp:Label ID="L_Traducir" runat="server" Text="Idioma a traducir"></asp:Label><br />
                <asp:DropDownList ID="DDL_Idioma" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2" DataTextField="nombre" DataValueField="id_idioma">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="buscaidioma" TypeName="Logica.Lparametriza"></asp:ObjectDataSource>
&nbsp;&nbsp;
                <br />
            </td>
            <td class="auto-style14">
                <asp:Label ID="L_Formularios" runat="server" Text="Formularios"></asp:Label>
                <br />
                <asp:DropDownList ID="DDL_Formularios" runat="server" DataSourceID="ObjectDataSource3" DataTextField="nombre" DataValueField="id_formulario" AutoPostBack="True">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="buscarformularios" TypeName="Logica.Lparametriza"></asp:ObjectDataSource>
            </td>
            <td class="auto-style14">
                <br />
                <asp:Label ID="L_Componentes" runat="server" Text="Componentes"></asp:Label>
                <br />
                <asp:DropDownList ID="DDL_Componentes" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4" DataTextField="componente" DataValueField="componente" OnSelectedIndexChanged="DDL_Componentes_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="cargarcomponentes" TypeName="Logica.Lparametriza">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_Idioma" DefaultValue="2" Name="id_idioma" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="DDL_Formularios" DefaultValue="1" Name="id_formulario" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
            </td>
            <td class="auto-style14">
                <asp:Label ID="L_Traduccion" runat="server" Text="Traduccion"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Ncomponentes" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFV_Traduccion" runat="server" ControlToValidate="TB_Idioma" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Traduccion" runat="server" ControlToValidate="TB_Ncomponentes" Display="Dynamic" ErrorMessage="Solo letras" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z ñÑáéíóúÁÉÍÓÚ ]+$" ValidationGroup="2"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" CssClass="btn-danger" Text="Agregar Traduccion" ValidationGroup="2" OnClick="Button1_Click1" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style10" colspan="4">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="ObjectDataSource5" GridLines="Horizontal">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="mostrarallcomponentes" TypeName="Logica.Lparametriza"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

