<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaFormaPago.aspx.cs" Inherits="e_comcerce.AltaFormaPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table class="table">
  <thead>
    <tr>
      <th scope="col">ID</th>      
      <th scope="col">Descripcion</th>
     
    </tr>
  </thead>
  <tbody>
    <tr>
     
      <td> <%: objFormaPago.IdFormaPago %> </td>      
      <td><%: objFormaPago.Descripcion %></td>
    </tr>

       <tr>
                <td> <p> ¿Desea dar de alta esta Forma de Pago? </p></td>
                <td> <asp:Button ID="btnAceptar" CssClass="btn btn-success" onclick="btnAceptar_Click" runat="server" Text="Aceptar" /> </td>
                <td> <asp:Button ID="btnCancelar" onclick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" /> </td>
               
            </tr>

   
  </tbody>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
