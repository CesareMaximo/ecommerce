<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVentaRegistro.aspx.cs" Inherits="e_comcerce.DetalleVentaRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">Producto</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Precio</th>
                 <th scope="col">Imagen</th>
               
            </tr>
        </thead>
        <tbody>

            <%foreach (CapaDominio.DetalleVenta item in listaDetalle)
                {
            %>
            <tr>
                
                <td> <%: item.IdProducto.Descripcion %></td>
                <td><%: item.Cantidad %></td>
                <td> <%: item.Precio %></td>
                <td> <img src="<%: item.IdProducto.UrlImagen %>" width="50px" alt="Alternate Text" /></td>
                
                
            </tr>

            <%    } %>

             <tr>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col">Total: $<%: Total %></th>
            </tr>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
