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
           <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtDescripcion" runat="server">  </asp:TextBox>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
            <asp:Button ID="btnAceptar" onclick="btnAceptar_Click" class="btn btn-success" runat="server" Text="Aceptar" />
            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" class="btn btn-danger" runat="server" Text="Cancelar" />
        </div>

    </div>

</asp:Content>
