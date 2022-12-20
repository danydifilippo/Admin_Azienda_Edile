<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SchedaDip.aspx.cs" Inherits="Admin_Azienda_Edile.SchedaDip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="text-center" runat="server" id="lblMessages" visible="false">
        <asp:Label ID="lblPayInsert" runat="server" Text="" Visible="false" ForeColor="ForestGreen"></asp:Label>
        <asp:Label ID="lblErrore" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="card">
        <h5 class="card-header">
            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCognome" runat="server" Text=""></asp:Label>
        </h5>
        <div class="card-body">
            <h5 class="card-title">
                <asp:Label ID="lblMansione" runat="server" Text=""></asp:Label></h5>
            <p class="card-text">
                <asp:Label ID="lblIndirizzo" runat="server" Text=""></asp:Label></p>
            <p class="card-text">
                <asp:Label ID="lblCF" runat="server" Text=""></asp:Label></p>
            <p class="card-text">
                <asp:Label ID="lblConiugato" runat="server" Text=""></asp:Label></p>
            <p class="card-text">
                <asp:Label ID="lblFigli" runat="server" Text=""></asp:Label></p>
            <p class="card-text">
                <asp:Label ID="lblStipendio" runat="server" Text=""></asp:Label></p>
            <asp:Button ID="AddPay" runat="server" Text="Aggiungi Pagamento" OnClick="AddPay_Click"  CssClass="btn btn-outline-success" />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Index.aspx" CssClass="btn btn-outline-info">Torna alla lista Dipendenti</asp:LinkButton>
          </div>
            <div ID="Payment" runat="server" visible="false">
            <h2>Aggiungi Pagamento per <asp:Label ID="lblDip" runat="server" Text=""></asp:Label></h2>
            <div class="mb-3">
                <label class="form-label">Tipo di pagamento:</label>
                <asp:DropDownList ID="ddlTipoStip" runat="server"></asp:DropDownList>
            </div>
                <div class="mb-3">
                    <label class="form-label">Importo:</label>
                    <asp:TextBox ID="txtImporto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Eseguito il:</label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </div>
                <asp:Button ID="SavePay" runat="server" Text="Inserisci Pagamento" OnClick="SavePay_Click"  />
            </div>
        </div>
    <asp:GridView ID="GridViewPag" runat="server" AutoGenerateColumns="false" 
        ItemType="Admin_Azienda_Edile.Gestione" CssClass="table table-bordered mt-3">
        <Columns>
            <asp:TemplateField HeaderText="Pagato">
                <ItemTemplate>
                    <p><%# Item.TipoStipendio %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data">
                <ItemTemplate>
                    <p><%# Item.DataPag %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Importo">
                <ItemTemplate>
                    <p><%# Item.ImportoPag %></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
