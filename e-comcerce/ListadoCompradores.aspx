<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCompradores.aspx.cs" Inherits="e_comcerce.ListadoCompradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1 class="col-md-8 col-md-offset-2">Listado Clientes</h1>
    </div>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <table id="usuariosList" class="table table-bordered table-hover table-striped">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>DNI</th>
                        <th>Domicilio</th>
                        <th>Celular</th>
                        <th>E-mail</th>
                    </tr>
                </thead>
                <tbody id="tbl_body_table">
                    <!-- DATA POR MEDIO DE AJAX-->
                </tbody>
                <tfoot>
                    <tr>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>DNI</th>
                        <th>Domicilio</th>
                        <th>Celular</th>
                        <th>E-mail</th>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="javascript/Compradores.js" type="text/javascript"></script>
</asp:Content>