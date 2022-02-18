<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarProducto.aspx.cs" Inherits="e_comcerce.EliminarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card text-center">
       
        <div class="card-center" width="100%" style="border-radius:20px; width: 80rem;border: solid 1px black; padding: 10px; margin: 15px; ">
             <div class="card-header">
            ELIMINAR PRODUCTO
        </div>
            <hr />
            <h5 class="card-title"><%: objProducto.Descripcion %></h5>
            <img src="<%: objProducto.UrlImagen %>" alt="Alternate Text" width="100%" />
            <p class="card-text">¿Desea eliminar este producto?</p>
            <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" class="btn btn-success" runat="server" Text="Aceptar" />
            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" class="btn btn-danger" runat="server" Text="Cancelar" />
        </div>
        
    </div>

</asp:Content>
