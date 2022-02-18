<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosAdmin.aspx.cs" Inherits="e_comcerce.ProductosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div style="display: flex; flex-direction: row; flex-wrap: wrap; " >
    <% foreach (CapaDominio.Productoss pro in ListaProducto)
        
        { %>
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="<%: pro.UrlImagen!=""? pro.UrlImagen : "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" %>" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">$ <%: pro.Precio %></h5>
            <p class="card-text"> <%: pro.Descripcion %></p>
            <hr />
            <a href="EliminarProducto.aspx?id=<%: pro.IdProducto %>" style="border-radius:20px;" class="btn btn-danger">Eliminar</a>
            <hr />
            <a href="ModificarProducto.aspx?id=<%: pro.IdProducto %>" style="border-radius:20px;" class="btn btn-success">Modificar</a>
            
        </div>
    </div>
        </tr>
    <%   } %>

</asp:Content>
