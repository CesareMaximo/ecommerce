<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="e_comcerce.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 
    <div class="col-2" > </div>
    <div class="col-2" >
        <div class="mb-3">
        <label for="txtEmail" class="form-label">Email: </label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        <div id="emailHelp" class="form-text">.</div>
    </div>
    <div class="mb-3">
        <label for="txtCelular" class="form-label">Celular:</label>

        <asp:TextBox ID="txtCelular" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="txtDescripcion" class="form-label">Descipcion de su problema:</label>

        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
        <hr />
    <asp:Button ID="btnEnviar" OnClick="btnEnviar_Click" CssClass="btn btn-primary" runat="server" Text="Enviar" />

    <div class="col-2" > </div>

        </div>
  
</asp:Content>
