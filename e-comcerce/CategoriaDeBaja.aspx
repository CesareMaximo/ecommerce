<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaDeBaja.aspx.cs" Inherits="e_comcerce.CategoriaDeBaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


     <table class="table">
        <thead>
            <tr  >

                <th  scope="col">ID</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Eliminar</th>
            </tr>
        </thead>
        <tbody>
            
            
            <% foreach (CapaDominio.Categoria item in listaCategoriaBaja)
                {
            %>
            <tr>
                
                <td> <%: item.IdCategoria %></td>
                <td><%: item.Descripcion %></td>
                <td> <a class="btn btn-success" href="CategoriaAdmin.aspx?id=<%: item.IdCategoria %>">Dar de Alta</a> </td>
            </tr>

            <% } %>
        </tbody>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
