<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Site.Master" CodeBehind="Default.aspx.cs" Inherits="ProjetoClientesWeb.Views.ConsultaClientes" %>

<script runat="server">

</script>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

    <h4>Consulta de Clientes</h4>

    <div id="Msg" runat="server" role="alert" style="display: none">
        <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
        <asp:Button CssClass="close" runat="server" OnClick="EsconderMsg" Text="x" BorderStyle="None" Style="background: none" />
    </div>
    <asp:GridView ID="GridViewClientes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridViewClientes_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="CPF" DataNavigateUrlFormatString="CadastroClientes.aspx?CPF={0}" Text="Detalhes" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    <br />

</asp:Content>