<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminFormaPago.aspx.cs" Inherits="e_comcerce.AdminFormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <table class="table">
        <thead>
            <tr>
                <th scope="col">ID</th>                
                <th scope="col">Descripcion</th>
                <th scope="col">Estado</th>
                <th scope="col">Eliminar</th>
                <th scope="col">Dar alta</th>
            </tr>
        </thead>
        <tbody>

            <tr>
                 
                 <td> <a class="btn btn-success" href="RegistrarFormaPago.aspx">Agregar Forma de Pago</a></td>
             </tr>

            <% foreach (CapaDominio.FormaPago item in listaForma)
                {
            %>

            <tr>
                <td><%: item.IdFormaPago %></td>                
                <td><%: item.Descripcion %></td>

                <%if (item.Estado == true)
                    { %>
                <td>Activo</td>

                <%}
                    else
                    {%>

                <td>Forma de Pago dada de baja</td>

                <% }%>

                <td><a href="EliminarFormaPago.aspx?id=<%: item.IdFormaPago %>" class="btn btn-danger">Eliminar</a> </td>

                <%if (item.Estado == false)
                    {
                %>
                    <td><a href="AltaFormaPago.aspx?id=<%: item.IdFormaPago %>" class="btn btn-success">Dar Alta</a></td>
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
