<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="e_comcerce.Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
.dropdown {
  position: relative;
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  padding: 12px 16px;
  z-index: 1;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>



    <table class="table">
        <thead>
            <tr>
                <th scope="col">Descripcion</th>
                <th scope="col">Precio</th>
                <th scope="col">Cantidad</th>
                  <th scope="col">Imagen</th>
            </tr>
        </thead>
        <tbody>

            <% foreach (CapaDominio.Carro pro in carrito)
                {
        %>
            <tr>

                <td><%: pro.Producto.Descripcion %></td>
                <td><%:pro.Producto.Precio %></td>
                <td><%:pro.Cantidad %></td>
                <td> <img src="<%: pro.Producto.UrlImagen %>" width="50px" alt="Alternate Text" /></td>

            </tr>

            <%   } %>
            <tr>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col"></th>
                <th scope="col">Total: $<%:total %></th>
            </tr>
        </tbody>
    </table>
    <div>

        <asp:DropDownList ID="dplEnvio" runat="server">
            <asp:ListItem  Value="1">Compra con envio ($1000) </asp:ListItem>
            <asp:ListItem Value="2">Retiro por el local (Gratis)</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div>
        <asp:DropDownList  ID="dropFormaPago" runat="server"></asp:DropDownList>


    </div>


   
    <form>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Dirección de entrega (si es necesario)</label>
            <asp:TextBox ID="txtDireccionEnvio" maxlength="150"  runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Aclaración de sobre la compra: </label>
            <asp:TextBox ID="txtAclaracion" maxlength="300"  runat="server"></asp:TextBox>
        </div>

        </form>

       

   

        <hr />


        <asp:Button ID="btnFinalizarVenta" CssClass="btn btn-success" OnClick="btnFinalizarVenta_Click" runat="server" Text="Finalizar Venta" />
</asp:Content>
