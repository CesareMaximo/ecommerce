<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroVentas.aspx.cs" Inherits="e_comcerce.RegistroVentas" %>

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
                <th scope="col">Estado</th>
                <th scope="col">ID del Cliente</th>
                <th scope="col">Haz Click para ver todos los detalles</th>

            </tr>
        </thead>
        <tbody>
            <% foreach (CapaDominio.Ventas item in listaVentas)
                {
            %>
            <tr>

                <td><%: item.IdVenta %></td>
                <td>$<%:item.Total %></td>
                <td><%:item.FechaVenta %></td>
                <td><%:item.DescripcionVenta %></td>
                <% if (item.EstadoEnvio == true)
                    {
                %>
                <td><%: item.DireccionEnvio %></td>
                <% }  %>
                <% else
                    {
                %>

                <td>Retira por el local</td>
                <%  } %>




                <% if (item.Estado == true)
                    { %>
                <td>Venta no enviada</td>
                <%}
                    else
                    {%>
                <td> Venta ya enviada </td>
                <%} %>
                <td><%: item.IdUsuario %></td>
                <td><a class="btn btn-success" href="DetalleVentaRegistro.aspx?id=<%:item.IdVenta %>">Ver Detalles de Venta</a></td>
            </tr>

            <%  } %>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
