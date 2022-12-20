<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Admin_Azienda_Edile.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-5">
            <div class="text-center" runat="server" id="lblMessages" visible="false">
                <asp:Label ID="lblErrore" runat="server" Text="" visible="false"></asp:Label>
            </div>
        <asp:LinkButton ID="lbinsert" runat="server" PostBackUrl="~/AggiungiOperaio.aspx" CssClass="text-decoration-none pb-4" ForeColor="#0e6ef8"><i class="bi bi-person-fill-add"></i>Inserisci Anagrafica Dipendente</asp:LinkButton>
        <asp:GridView ID="GWDipendenti" CssClass="table table-bordered mt-3" runat="server" 
            AutoGenerateColumns="false" ItemType="Admin_Azienda_Edile.Gestione">
            <Columns>
                <asp:TemplateField HeaderText="ID Dip">
                    <ItemTemplate>
                        <p> <%# Item.IdDipendente %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <p> <%# Item.Nome %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cognome">
                   <ItemTemplate>
                    <p> <%# Item.Cognome %> </p>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mansione">
                    <ItemTemplate>
                    <p> <%# Item.Mansione %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stipendio">
                    <ItemTemplate>
                    <p> <%# Item.StipendioMensile %> </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Scheda Cliente">
                    <ItemTemplate>
                        <div class="text-center">
                            <asp:LinkButton ID="SchedaDip" runat="server"><a href="SchedaDip.aspx?IdDipendente=<%# Item.IdDipendente %>"><i class="bi bi-person-video2"></i></a></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Aggiungi Pagamento">
                    <ItemTemplate>
                        <div class="text-center">
                            <asp:LinkButton ID="AggiungiPag" runat="server"><a href="SchedaDip.aspx?IdDipendente=<%# Item.IdDipendente %>"><i class="bi bi-folder-plus"></i></a></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
