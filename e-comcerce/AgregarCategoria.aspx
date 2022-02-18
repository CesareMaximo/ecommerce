<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="e_comcerce.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mb-3">
            <label class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />
    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" class="btn btn-danger" runat="server" Text="Cancelar" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
