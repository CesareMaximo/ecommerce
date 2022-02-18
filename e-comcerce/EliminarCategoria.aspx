<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarCategoria.aspx.cs" Inherits="e_comcerce.EliminarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr  >

                <th  scope="col">ID</th>
                <th scope="col">Descripcion</th>
                
            </tr>
        </thead>
        <tbody>
            
            <tr>
                
                <td> <%: objCategoria.IdCategoria %></td>
                <td> <%: objCategoria.Descripcion %> </td>
               
            </tr>

             <tr>
                <td> <p> ¿Desea Eliminar esta categoria? Recordá que al borrarla, se borrarán todos los producto de la categoria</p></td>
                <td> <asp:Button ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" /> </td>
                <td> <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" /> </td>
               
            </tr>
           
        </tbody>
    </table>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
