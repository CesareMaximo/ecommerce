<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarAdmin.aspx.cs" Inherits="e_comcerce.EliminarAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
  <thead>
    <tr>
      <th scope="col">ID</th>
      <th scope="col">Nombre Comercio</th>
      <th scope="col">Email</th>
     
    </tr>
  </thead>
  <tbody>
    <tr>
     
      <td><%: objAdmin.IdAdminCommerce%></td>
      <td><%: objAdmin.NombreComercio %></td>
      <td><%: objAdmin.Email %></td>
    </tr>

       <tr>
                <td> <p> ¿Desea Eliminar este administrador? </p></td>
                <td> <asp:Button ID="btnAceptar" CssClass="btn btn-success" onclick="btnAceptar_Click" runat="server" Text="Aceptar" /> </td>
                <td> <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" /> </td>
               
            </tr>

   
  </tbody>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
