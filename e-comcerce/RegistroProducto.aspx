<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroProducto.aspx.cs" Inherits="e_comcerce.RegistroProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="mb-3">
            <label class="form-label">Categoria</label>
            <asp:DropDownList ID="dropCategoria" runat="server"></asp:DropDownList>

        </div>
        <div class="mb-3">
            <label class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Stock</label>
            <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Ponga aqui el url de la imagen</label>
            <asp:TextBox ID="txtURL" CssClass="form-control" runat="server"></asp:TextBox>
        </div>


        <asp:Button ID="btnRegistrar" OnClick="btnRegistrar_Click" CssClass="btn btn-success" runat="server" Text="Registrar" />
    </form>

</asp:Content>
