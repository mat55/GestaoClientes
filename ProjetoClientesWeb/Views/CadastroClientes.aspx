<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Site.Master" CodeBehind="CadastroClientes.aspx.cs" Inherits="ProjetoClientesWeb.Views.CadastroClientes" %>

<script runat="server">

</script>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

    <div class="card">
        <div class="card-header">
            <h4 class="card-title">
                <% if (Request.QueryString["CPF"] == null)
                    { %>
                Cadastro de Clientes
                <%    }
                    else
                    { %> 
                Dados do Clientes
                <%    }%>

            </h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div id="Msg" runat="server" class="alert alert-danger alert-dismissible fade show" role="alert" style="display: none">
                    <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                    <asp:Button CssClass="close" runat="server" OnClick="EsconderMsg" Text="x" BorderStyle="None" Style="background: none" />
                </div>
                <div class="col-md-12">
                    <div class="form-group col-md-4">
                        <asp:Label ID="lbNome" runat="server" Text="Nome*"></asp:Label>
                        <asp:TextBox ID="txtNome" runat="server"  CssClass="form-control" ClientIDMode="Inherit" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:Label ID="lbCPF" runat="server" Text="CPF*"></asp:Label>
                        <asp:TextBox ID="txtCPF" runat="server"  CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label ID="lbTipo" runat="server" Text="Tipo de Cliente*"></asp:Label>
                        <asp:DropDownList ID="dropTipo" runat="server"  CssClass="form-control" AutoPostBack="true">
                            <asp:ListItem Value="">(Selecione)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:Label ID="lbSexo" runat="server" Text="Sexo*"></asp:Label>
                        <asp:RadioButton ID="rbSexoM" GroupName="rbSexo" runat="server"  Text="Masculino" AutoPostBack="true" />
                        <asp:RadioButton ID="rbSexoF" GroupName="rbSexo" runat="server"  Text="Feminino" AutoPostBack="true" />
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label ID="lbSituacao" runat="server" Text="Situação do Cliente*"></asp:Label>
                        <asp:DropDownList ID="dropSituacao" runat="server"  CssClass="form-control" AutoPostBack="true">
                            <asp:ListItem Value="">(Selecione)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-12">
                        <% if (Request.QueryString["CPF"] == null)
                            { %>
                        <asp:Button ID="CadastraClientes" runat="server" CssClass="btn btn-success" Style="font-family: Arial, Helvetica, sans-serif" Text="Salvar" OnClick="Cadastra" />
                        <%    }
                            else
                            { %>
                        <asp:Button ID="AtualizaClientes" runat="server" CssClass="btn btn-primary" Style="font-family: Arial, Helvetica, sans-serif" Text="Atualizar" OnClick="Atualiza" />
                        <asp:Button ID="ExcluirCliente" runat="server" CssClass="btn btn-danger" Style="font-family: Arial, Helvetica, sans-serif" Text="Excluir" OnClick="Excluir" />
                        <%    }%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
