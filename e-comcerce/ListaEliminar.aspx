<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEliminar.aspx.cs" Inherits="e_comcerce.ListaEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <table class="table">
        <thead>
            <tr>
                <th scope="col">Descripcion</th>
                <th scope="col">Precio</th>
                <th scope="col">Stock</th>
                  <th scope="col">Imagen</th>
                 <th scope="col">Eliminar</th>
            </tr>
        </thead>
        <tbody>

            <% foreach (CapaDominio.Productoss item in ListaProducto)
                {

              
        %>
            <tr>

                <td><%: item.Descripcion %></td>
                <td><%:item.Precio %></td>
                <td><%:item.Stock %></td>
                <td> <img src="<%: item.UrlImagen %>" width="50px" alt="Alternate Text" /></td>
                 <td><a href="ConfirmarEliminacion.aspx?id=<%: item.IdProducto %>" class="btn btn-danger">Eliminar</a></td>   

            </tr>

            <%   } %>
            <tr>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </tbody>
    </table>



</asp:Content>
