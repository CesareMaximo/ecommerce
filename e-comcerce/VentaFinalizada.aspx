<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentaFinalizada.aspx.cs" Inherits="e_comcerce.VentaFinalizada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="jumbotron">
        <h1>¡Gracias por su compra!</h1>
        <p class="lead">Llegará a su mail una factura con su detalle de venta</p>
        <p class="lead">Su numero de venta es: #<%: ID_Venta %></p>

    </div>
</asp:Content>
