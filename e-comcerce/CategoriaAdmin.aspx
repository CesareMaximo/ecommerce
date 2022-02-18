<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaAdmin.aspx.cs" Inherits="e_comcerce.CategoriaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Al Eliminar una categoria, se dará de baja la misma y todos sus productos </p>
    <table class="table">
        <thead>
            <tr  >

                <th  scope="col">ID</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Eliminar</th>
            </tr>
        </thead>
        <tbody>
             <tr>
                 <td><a class="btn btn-warning" href="CategoriaDeBaja.aspx">Ver Categorias dadas de baja</a> </td>
                 <td> <a class="btn btn-success" href="AgregarCategoria.aspx">Agregar Categoria Nueva</a></td>
             </tr>
            
            <% foreach (CapaDominio.Categoria item in listaCategoria)
                {
            %>
            <tr>
                
                <td> <%: item.IdCategoria %></td>
                <td><%: item.Descripcion %></td>
                <td> <a class="btn btn-danger" href="EliminarCategoria.aspx?id=<%: item.IdCategoria %>">Eliminar</a> </td>
            </tr>

            <% } %>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
