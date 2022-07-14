<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroBusca.aspx.cs" Inherits="TVox.CadastroBusca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h3>Treino Vox</h3>
    </div>
    <br />

    <table>
        
        <tr>                      
            <td>
                <asp:Label runat="server">ID:</asp:Label>
                <asp:Label ID="txtId" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Nome:</td>
            <td>
                <br />
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control txtNome"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Idade:</td>
            <td class="modal-sm">
                <br />
                <asp:TextBox ID="txtIdade" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            
           
            <td class="modal-sm" style="width: 124px">Telefone:</td>
            <td>
                <br />
                <asp:TextBox ID="txtTel" runat="server" CssClass="form-control txtTel"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="ExpressaoRegular" runat="server" ControlToValidate="txtTel" ErrorMessage="Telefone inválido." ValidationExpression="\([0-9]{2}\) 9?[0-9]{4}-[0-9]{4}" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 124px">Gênero:</td>
            <td>
                <br />
                <asp:DropDownList ID="txtGen" runat="server" CssClass="dropdown-header form-control">
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
                <asp:TextBox ID="txtDtc" runat="server" TextMode="Date" CssClass="form-control" Width="180px"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td class="modal-sm" style="width: 609px">
                <asp:Button ID="btInserir" runat="server" Text="Cadastrar" CssClass="btn btn-sm btn-success" OnClick="BtnInserir" />
                <asp:Button ID="btAtt" runat="server" Text="Atualizar" CssClass="btn btn-sm btn-info" OnClick="btnAtt" />
                <asp:Button ID="btDel" runat="server" Text="Deletar" CssClass="btn btn-sm btn-danger" OnClick="btnDel" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 609px">
                <asp:Button ID="btBuscar" runat="server" Text="Buscar por Nome" CssClass="btn btn-sm btn-warning" OnClick="btnBuscar" />
                <asp:TextBox ID="txtNomeBusca" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>
        </tr>

    </table>

    <asp:GridView ID="Griddb" runat="server" Width="550px" OnSelectedIndexChanged="btnSelect">
       
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
        </Columns>
    </asp:GridView>


</asp:Content>
