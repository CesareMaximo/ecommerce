<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="e_comcerce.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <% if (carrito.Count == 0)
        { %>

    <div class="jumbotron">
        <h1>¡Carrito de compras vacio!</h1>
        <p class="lead">Para ver esta ventana, por favor selecione el producto que desee comprar</p>
        <p><a href="Productos.aspx" class="btn btn-primary btn-lg">Hace click Acá! &raquo;</a></p>

    </div>

    <%}
        else
        {
    %>

    <div style="display: flex; flex-direction: row; flex-wrap: wrap;">
        <% foreach (var pro in carrito)
            { %>


        <div class="card" width="100%" style="border-radius: 20px; width: 18rem; border: solid 1px black; padding: 10px; margin: 15px;">
            <img style="border-radius: 20px;" src="<%: pro.Producto.UrlImagen != "" ? pro.Producto.UrlImagen : "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" %>" class="card-img-top" alt="..." width="158" height="158">
            <div class="card-body">
                <h5 class="card-title">$ <%: pro.Producto.Precio %></h5>
                <p class="card-text"><%: pro.Producto.Descripcion %></p>
                 <p class="card-text"><%: pro.Cantidad %></p>
                <a href="Carrito.aspx?id=<%: pro.Producto.IdProducto %>" style="border-radius: 20px;" class="btn btn-danger">Eliminar del carrito</a>
            </div>
        </div>

  
    <%   } %>

        </div>

    <hr />
    <div>

        

        <a href="Venta.aspx" class="btn btn-success">Iniciar compra </a>
    </div>
    <div>
        <p style="text-align:right;"  > Total : $<%: total %></p>

        
    </div>

    <% } %>
</asp:Content>
