<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TVox.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div cssclass="form-group">
        <asp:Label CssClass="form-control" runat="server" ID="txtId" Visible="false"></asp:Label>
    </div>

    <div id="cadastros" runat="server" style="width: 30%; padding: 35px; display: none">

        <div cssclass="form-group">
            <label>Nome</label>
            <asp:TextBox CssClass="form-control txtNome" runat="server" ID="txtNome"></asp:TextBox>
        </div>
        <div cssclass="form-group">
            <label>Idade</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtIdade"></asp:TextBox>
        </div>
        <div cssclass="form-group">
            <label>Telefone</label>            
            <asp:TextBox CssClass="form-control txtTelefone" runat="server" ID="txtTelefone"></asp:TextBox>
            <asp:RegularExpressionValidator ID="ExpressaoRegular" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Telefone inválido." ValidationExpression="\([0-9]{2}\) 9?[0-9]{4}-[0-9]{4}" />
        </div>


        <asp:Label runat="server" AssociatedControlID="txtGenero"><b>Genero</b></asp:Label><br />
        <asp:DropDownList CssClass="form-group" checked="" ID="txtGenero" runat="server" OnSelectedIndexChanged="btnCad">
            <asp:ListItem Text="Masculino" />
            <asp:ListItem Text="Feminino" />
        </asp:DropDownList>

        <div cssclass="form-group">
            <label>Data de Cadastro</label>
            <asp:TextBox CssClass="form-control" runat="server" TextMode="Date" ID="txtDataCad"></asp:TextBox>
        </div>
        <br />
        <asp:Button runat="server" ID="IDbtnCad" CssClass="btn btn-sm btn-success" Text="Salvar" OnClick="btnCad" />

        <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-sm btn-default" Text="Cancelar" OnClick="btnCancel_Click"
            Style="margin-left: 20px" />
        <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-sm btn-danger" Text="Deletar" OnClick="btnDelete_Click"
            Style="margin-left: 30px" />

    </div>

    <div id="idGrid" runat="server">
        <asp:Button ID="cmdNew" runat="server" Text="Cadastro" CssClass="btn btn-sm btn-primary newCad" OnClick="cmdNew_Click" />

        <asp:GridView runat="server" ID="GView" CellPadding="4" ForeColor="#333333" CssClass="text-lowercase table table-responsive" Width="36%"
            ShowHeaderWhenEmpty="true">

            <Columns>
                <asp:TemplateField HeaderText="Opções" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="cmdEdit" runat="server" Text="Editar" CssClass="btn btn-sm" OnClick="cmdEdit_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

        </asp:GridView>
    </div>

</asp:Content>
