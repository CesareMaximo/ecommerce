<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarFormaPago.aspx.cs" Inherits="e_comcerce.RegistrarFormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <div class="mb-3">
            <label class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" TextMode="SingleLine" maxlength="30"  CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    <asp:Button ID="btnAceptar" onclick="btnAceptar_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />
    <asp:Button ID="btnCancelar" onclick="btnCancelar_Click" class="btn btn-danger" runat="server" Text="Cancelar" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
