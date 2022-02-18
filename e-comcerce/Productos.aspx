<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="e_comcerce.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <hr />

    <div style="display: flex; flex-direction: row; flex-wrap: wrap; " >
    <% foreach (var pro in listaProductos)
        {
            if (pro.IdCategoria.IdCategoria == idCategoriaAux)
            {


          %>
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="<%: pro.UrlImagen != "" ? pro.UrlImagen : "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" %>" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">$ <%: pro.Precio %></h5>
            <p class="card-text"> <%: pro.Descripcion %></p>
            <% if (pro.Stock == 0)
                { %>
            <p class="card-text" style="color:red"> !Producto Sin Stock!</p>
            <%} %>
            <a href="Productos.aspx?id=<%: pro.IdProducto %>" style="border-radius:20px;" class="btn btn-success">Añadir al carrito 🛒</a>
        </div>
    </div>
        </tr>
    <% }
        } %>

        </div>
</asp:Content>
