<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscaVox.aspx.cs" Inherits="TVox.Busca_Vox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class= "container text-center">

        <br />
        <table>
            <tr>
                <td class="modal-sm" style="width: 609px">
                    <br />
                    <asp:Button ID="IdSearchContact" runat="server" Text="Buscar por Nome" CssClass="btn btn-sm btn-warning txtNome" OnClick="SearchContact" />
                    <asp:TextBox ID="textSearchContact" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
        </table>

        <asp:GridView ID="DbGridView" runat="server" Width="1439px" CssClass="table table-striped table-bordered">
        </asp:GridView>
    </div>

</asp:Content>
