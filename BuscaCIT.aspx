<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscaCIT.aspx.cs" Inherits="TVox.BuscaCIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <br />
    <div class="container">

        <div class="row">

            <div class="col-sm-2">
                <asp:Label runat="server" Text="Nome:" />
                <asp:TextBox ID="textSearchName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" Text="Gênero:" />
                <asp:DropDownList ID="textSearchGender" runat="server" CssClass="dropdown-header form-control">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" Text="Idade:" />
                <asp:TextBox ID="textSearchAge" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" Text="Telefone:" />
                <asp:TextBox ID="textSearchPhone" runat="server" CssClass="form-control txtTel"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Label runat="server" Text="Data de Cadastro:" />
                <asp:TextBox ID="textSearchDate" runat="server" TextMode="Date" CssClass="form-control" Style="margin-left: 0"></asp:TextBox>
            </div>

            <div class="col-sm-2">
                <br />
                <asp:Button runat="server" Text="Buscar" OnClick="SearchContact" CssClass="btn btn-sm btn-primary" />
            </div>
        </div>
        <br />
        <asp:Button runat="server" Text="Listar Todos" OnClick="ListAll" CssClass="btn btn-sm btn-primary" />
    </div>
    <br />
    <asp:GridView ID="DbGridView" runat="server" CssClass="table table-striped table-bordered" Width="1023px">
    </asp:GridView>








</asp:Content>
