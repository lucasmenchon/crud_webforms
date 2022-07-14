<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDb.aspx.cs" Inherits="TVox.CadastroDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />





    <table class="nav-justified">
        <tr>
            <td colspan="2" style="height: 19px">Cadastro no Database<br />
                <br />
            </td>
            <td class="modal-sm" style="height: 19px; width: 421px"></td>
            <td rowspan="9">
                <asp:GridView ID="dbView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="224px" Width="450px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                        <asp:BoundField DataField="Idade" HeaderText="Idade" SortExpression="Idade" />
                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" SortExpression="Telefone" />
                        <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                        <asp:BoundField DataField="DataCadastro" HeaderText="DataCadastro" SortExpression="DataCadastro" DataFormatString="{0:MM/dd/yyyy}" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Contato]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 19px">
                <asp:TextBox ID="txtId" runat="server" Width="175px" Visible="False"></asp:TextBox>
            </td>
            <td class="modal-sm" style="height: 19px; width: 421px"></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lbNome" runat="server" Text="Nome"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:TextBox ID="txtNome" runat="server" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Label ID="lbIdade" runat="server" Text="Idade"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:TextBox ID="txtIdade" runat="server" Width="40px" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Label ID="lbTel" runat="server" Text="Telefone"></asp:Label>
                <br />
&nbsp;<asp:TextBox ID="txtTelefone" runat="server" Width="176px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Label ID="lbGen" runat="server" Text="Gênero"></asp:Label>
                <br />
&nbsp;<asp:DropDownList ID="txtGen" runat="server">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Label ID="lbDataCad" runat="server" Text="Data de Cadastro"></asp:Label>
                <br />
                <asp:TextBox ID="txtDataCad" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Adicionar" CssClass="btn btn-sm btn-default" OnClick="btnAdd_Click" />
                &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Atualizar" CssClass="btn btn-sm btn-default" OnClick="btnUpdate_Click" />
                &nbsp;<asp:Button ID="btnDel" runat="server" Text="Deletar" CssClass="btn btn-sm btn-default" OnClick="btnDel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <asp:Button ID="btnCan" runat="server" Text="Cancelar" CssClass="btn btn-sm btn-default" Width="266px" OnClick="btnCan_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 315px">
                <asp:Label ID="txtMsg" runat="server"></asp:Label>
            </td>
            <td style="width: 29px">&nbsp;</td>
            <td class="modal-sm" style="width: 421px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 315px">&nbsp;</td>
            <td style="width: 29px">&nbsp;</td>
            <td class="modal-sm" style="width: 421px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 315px; height: 20px;"></td>
            <td style="width: 29px; height: 20px;"></td>
            <td class="modal-sm" style="width: 421px; height: 20px;"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 315px">&nbsp;</td>
            <td style="width: 29px">&nbsp;</td>
            <td class="modal-sm" style="width: 421px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>





</asp:Content>
