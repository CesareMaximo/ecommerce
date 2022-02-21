<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminClientes.aspx.cs" Inherits="e_comcerce.AdminClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Domicilio</th>
                <th scope="col">Celular</th>
                <th scope="col">Compras Cliente</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (CapaDominio.Usuario item in listaUsuario)
                { %>
            <tr>
                <td><%:item.IdUsuario %></td>
                <td><%: item.Nombre %></td>
                <td><%: item.Apellido %></td>
                <td><%: item.Domicilio %></td>
                <td><%: item.Celular %></td>
                <td><a class="btn btn-success" href="ComprasCliente.aspx?id=<%:item.IdUsuario %>">Ver Compras del cliente</a></td>


            </tr>
            <%   } %>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
