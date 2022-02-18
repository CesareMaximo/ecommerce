<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="errorStock.aspx.cs" Inherits="e_comcerce.errorStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>¡Producto Sin Stock!</h1>
        <p class="lead">Si ya agregaste varios al carrito sobre este mismo producto no se perderá, pero este no se sumará </p>
        <p><a href="Productos.aspx" class="btn btn-primary btn-lg">Seguir Comprando! &raquo;</a></p>

    </div>

</asp:Content>
