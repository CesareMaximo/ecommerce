<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="e_comcerce.Despacho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Total</th>
                <th scope="col">Fecha</th>
                <th scope="col">Aclaracion</th>
                <th scope="col">Direccion Envio</th>
                <th scope="col">Finalizar Venta</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (CapaDominio.Ventas item in listaVentaDespacho)
                {
            %>
            <tr>
               
                <td> <%: item.IdVenta %></td>
                <td>$<%:item.Total %></td>
                <td> <%:item.FechaVenta %></td>
                <td><%:item.DescripcionVenta %></td>
               <% if (item.EstadoEnvio == true) {
                       %>
               <td> <%: item.DireccionEnvio %></td>                 <% }  %>
                   <% else {
                       %>
              <td>Retira por el local</td>  
              <%  } %>
                <td><a class="btn btn-success" href="Despacho.aspx?id=<%:item.IdVenta %>">Concretar Venta</a></td>
            </tr>

            <%  } %>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
