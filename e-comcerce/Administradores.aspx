<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administradores.aspx.cs" Inherits="e_comcerce.Administradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">ID</th>                
                <th scope="col">Email</th>
                <th scope="col">Estado</th>
                <th scope="col">Eliminar</th>
                <th scope="col">Dar alta</th>
            </tr>
        </thead>
        <tbody>

            <tr>
                 
                 <td> <a class="btn btn-success" href="AgregarAdmin.aspx">Agregar Administrador</a></td>
             </tr>

            <% foreach (CapaDominio.Usuario item in listaAdmin)
                {
            %>

            <tr>
                <td><%: item.IdUsuario %></td>                
                <td><%: item.Email %></td>

                <%if (item.Estado == true)
                    { %>
                <td>Activo</td>

                <%}
                    else
                    {%>

                <td>Admin dado de baja</td>

                <% }%>

                <td><a href="EliminarAdmin.aspx?id=<%: item.IdUsuario %>" class="btn btn-danger">Eliminar</a> </td>

                <%if (item.Estado == false)
                    {
                %>
                    <td><a href="AltaAdmin.aspx?id=<%: item.IdUsuario %>" class="btn btn-success">Dar Alta</a></td>
                <%  }
                    else
                    {%>
                <td>X</td>
                <%} %>
            </tr>

            <%
                } %>
        </tbody>
    </table>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
