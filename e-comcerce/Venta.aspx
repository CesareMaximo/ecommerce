<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="e_comcerce.Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





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
        <asp:DropDownList ID="dropFormaPago" runat="server"></asp:DropDownList>


    </div>


   
    <form>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Dirección de entrega (si es necesario)</label>
            <asp:TextBox ID="txtDireccionEnvio" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Aclaración de sobre la compra: </label>
            <asp:TextBox ID="txtAclaracion" runat="server"></asp:TextBox>
        </div>

        </form>

       

   

        <hr />


        <asp:Button ID="btnFinalizarVenta" CssClass="btn btn-success" OnClick="btnFinalizarVenta_Click" runat="server" Text="Finalizar Venta" />
</asp:Content>
