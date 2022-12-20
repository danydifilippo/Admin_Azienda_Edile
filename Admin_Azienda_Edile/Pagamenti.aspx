<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Pagamenti.aspx.cs" Inherits="Admin_Azienda_Edile.Pagamenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-5">
            <div class="text-center" runat="server" id="lblMessages" visible="false">
                <asp:Label ID="lblErrore" runat="server" Text="" visible="false"></asp:Label>
            </div>
        <asp:GridView ID="GWPagamenti" CssClass="table table-bordered mt-3" runat="server" 
            AutoGenerateColumns="false" ItemType="Admin_Azienda_Edile.Gestione">
            <Columns>
                <asp:TemplateField HeaderText="Nome Dipendente">
                    <ItemTemplate>
                        <p> <%# Item.Cognome %> <%# Item.Nome %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo di Pagamento">
                    <ItemTemplate>
                        <p> <%# Item.TipoStipendio %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data">
                   <ItemTemplate>
                    <p> <%# Item.DataPag %> </p>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Importo">
                    <ItemTemplate>
                    <p> <%# Item.ImportoPag %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
