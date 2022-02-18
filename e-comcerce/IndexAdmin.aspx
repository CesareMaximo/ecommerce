<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="e_comcerce.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div style="display: flex; flex-direction: row; flex-wrap: wrap; " >
    
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://www.lluviadigital.com/wp-content/uploads/2020/02/e-commerce-que-es-Lluvia-Digital.jpg" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Registrar Producto</h5>
            <hr />
            <p class="card-text"> Aqui podrá registrar los productos que quiere vender </p>
           
            <a href="RegistroProducto.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>
   
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://thumbs.dreamstime.com/b/icono-de-vector-gesti%C3%B3n-asignaciones-que-puede-modificar-o-editar-f%C3%A1cilmente-204886127.jpg" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Eliminar o Modificar Producto</h5>
            <hr />
            <p class="card-text"> Aqui podrá eliminar o modificar un producto de su commerce</p>
           
            <a href="ProductosAdmin.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>

        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://cdn.shopify.com/s/files/1/2283/5833/files/envios.png?6800375330108925719/envios.png%20" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Despacho</h5>
            <hr />
            <p class="card-text"> Aqui podrá ver los productos que tiene que despachar o preparar para el retiro en el local</p>
           
            <a href="Despacho.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>

        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://us.123rf.com/450wm/brisker/brisker1605/brisker160500032/58489989-16-iconos-de-diferentes-categor%C3%ADas-de-productos-para-tiendas-online.jpg" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Agregar o eliminar una Categoria</h5>
            <hr />
            <p class="card-text"> Aqui podrá agregar o eliminar una Categoria</p>
           
            <a href="CategoriaAdmin.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>

        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://innovandodigital.com/wp-content/uploads/2020/08/orange-and-turquoise-illustration-social-media-strategy-presentation.jpg" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Registro de Ventas</h5>
            <hr />
            <p class="card-text"> Aqui podrá ver todas las ventas y sus detalles</p>
           
            <a href="RegistroVentas.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>


        </div>

</asp:Content>
