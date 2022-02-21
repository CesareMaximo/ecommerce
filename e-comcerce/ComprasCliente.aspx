<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComprasCliente.aspx.cs" Inherits="e_comcerce.ComprasCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <table class="table">
        <thead>
            <tr>
                <th scope="col">Numero de Venta</th>
                <th scope="col">Fecha</th>
                <th scope="col">Direccion de Envio/Retiro</th>
                <th scope="col">Total</th>
                <th scope="col">Estado</th>
                <th scope="col">Detalles de la Compra</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (CapaDominio.Ventas item in listaVentas)
                { %>


            <tr>

                <td><%: item.IdVenta %></td>
                <td><%: item.FechaVenta %></td>
                <td><%: item.DireccionEnvio %></td>
                <td>$<%: item.Total %></td>

                <%if (item.Estado == false && item.EstadoRetiro == true)
                    {%>
                <td>Listo para Retirar</td>
                <%}
                    else if (item.Estado == true && item.EstadoRetiro == true)
                    {
                %>
                <td>Preparando producto para su retiro</td>

                <% }
                    else if (item.Estado == false && item.EstadoEnvio == true)
                    { %>
                <td>Pedido en Camino</td>
                <%}
                    else if (item.Estado == true && item.EstadoEnvio == true)
                    { %>

                <td>Preparando producto para su envio</td>

                <%} %>

                <td><a class="btn btn-success" href="DetalleVentaCliente.aspx?id=<%: item.IdVenta %>">Ver Detalle de la Compra </a></td>
            </tr>

            <%    } %>
        </tbody>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
