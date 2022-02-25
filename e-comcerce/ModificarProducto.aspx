<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="e_comcerce.ModificarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card text-center">

        <div class="card-center" width="100%" style="border-radius: 20px; width: 80rem; border: solid 1px black; padding: 10px; margin: 15px;">
            <div class="card-header">
                MODIFICAR PRODUCTO
           
            </div>
            <hr />
            <h5 class="card-title"><%: objProducto.Descripcion %></h5>
            <img src="<%: objProducto.UrlImagen  %>" alt="Alternate Text" width="100%" />
            <p class="card-text">¿Desea modificar este producto?</p>
            <asp:Label ID="lblCat" runat="server" Text="Categoria: "></asp:Label>
            <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            <asp:Label ID="lbldes" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" TextMode="SingleLine" MaxLength="150" runat="server">  </asp:TextBox>
            <asp:Label ID="lblPrecio" runat="server" Text="Precio: $"></asp:Label>
            <asp:TextBox ID="txtPrecio" TextMode="Number" min="1" runat="server"></asp:TextBox>
              
            <asp:Label ID="lblStock" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtStock" TextMode="Number" min="1" runat="server"></asp:TextBox>
            
            <asp:Label ID="lblURL" runat="server" Text="URL Imagen: "></asp:Label>
            <asp:TextBox ID="txtURL" MaxLength="500" runat="server"></asp:TextBox>
            <hr />
            <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" class="btn btn-success" runat="server" Text="Aceptar" />
            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" class="btn btn-danger" runat="server" Text="Cancelar" />
        </div>

    </div>

</asp:Content>
