<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroVox.aspx.cs" Inherits="TVox.CadastroVox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h3>Treino Vox Padrões Projetos</h3>
    </div>
    <br />

    <table>

        <tr>
            <td>
                <asp:Label runat="server">ID:</asp:Label>
                <asp:Label ID="lblId" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Nome:</td>
            <td>
                <br />
                <asp:TextBox ID="textName" runat="server" CssClass="form-control txtNome"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Idade:</td>
            <td class="modal-sm">
                <br />
                <asp:TextBox ID="textAge" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Telefone:</td>
            <td>
                <br />
                <asp:TextBox ID="textPhone" runat="server" CssClass="form-control txtTel"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpression" runat="server" ControlToValidate="textPhone" ErrorMessage="Telefone inválido." ValidationExpression="\([0-9]{2}\) 9?[0-9]{4}-[0-9]{4}" />
                <br />
           
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Gênero:</td>
            <td>
                <br />
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown-header form-control">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Data de Cadastro:</td>
            <td>
                <br />
                <asp:TextBox ID="RegisterDate" runat="server" TextMode="Date" CssClass="form-control" Width="180px"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td class="modal-sm" style="width: 609px">
                <asp:Button ID="IdInsertContact" runat="server" Text="Cadastrar" CssClass="btn btn-sm btn-success" OnClick="RegisterContact" />
                <asp:Button ID="IdUpdateContact" runat="server" Text="Atualizar" CssClass="btn btn-sm btn-info" OnClick="UpdateContact" />
                <asp:Button ID="IdDeleteContact" runat="server" Text="Deletar" CssClass="btn btn-sm btn-danger" OnClick="DeleteContact" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
        </tr>

    </table>

    <asp:GridView ID="DbGridView" runat="server" Width="705px" OnSelectedIndexChanged="SelectContact" CssClass="table table-striped table-bordered">
    
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button">
                <ControlStyle CssClass="btn btn-sm btn-primary" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>

</asp:Content>