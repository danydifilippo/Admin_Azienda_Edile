<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AggiungiOperaio.aspx.cs" Inherits="Admin_Azienda_Edile.AggiungiOperaio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="text-center" runat="server" id="lblMessages" visible="false">
    <asp:Label ID="lblInserito" runat="server" Text="" visible="false"></asp:Label>
    <asp:Label ID="lblErrore" runat="server" Text="" visible="false"></asp:Label>
</div>
  <h2>Aggiungi Anagrafica Dipendente</h2>
  <div class="mb-3">
    <label class="form-label">Nome:</label>
      <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <label class="form-label">Cognome:</label>
      <asp:TextBox ID="txtCognome" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <label class="form-label">Indirizzo:</label>
      <asp:TextBox ID="txtIndirizzo" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <label class="form-label">Codice Fiscale:</label>
      <asp:TextBox ID="txtCF" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <label class="form-label">Coniugato:</label>
      <div class="form-control">
     <asp:CheckBox ID="ckbSi" runat="server" Text="Si" />
    </div>
  </div>
  <div class="mb-3">
    <label class="form-label">Figli a carico:</label>
      <asp:TextBox ID="txtFigli" runat="server" TextMode="Number" Min="0" CssClass="form-control"></asp:TextBox>
  </div>   
 <div class="mb-3">
    <label class="form-label">Mansione:</label>
      <asp:TextBox ID="txtMansione" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
     <div class="mb-3">
    <label class="form-label">StipendioMensile:</label>
      <asp:TextBox ID="txtStipendio" runat="server" TextMode="Number" Min="0" CssClass="form-control"></asp:TextBox>
  </div>
    <asp:Button ID="AddEmpl" runat="server" Text="Aggiungi Anagrafica" OnClick="AddEmpl_Click" CssClass="btn btn-outline-primary" />
</div>
</asp:Content>
