<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="e_comcerce.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>UTN E-Commerce | Ver Perfil</title>

    <script type="text/javascript">
        function ConfirmarModificacion() { return confirm("Desea confirmar los cambios?"); }
        function ConfirmarEliminacion() { return confirm("Desea confirmar la eliminacion de la cuenta?"); }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <LayoutTemplate>
        <div class="container">
            <div class="row" style="padding-top: 12px;"></div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2 text-center">
                    <form class="form-signin">
                        <div class="form-group col-md-10 text-center">
                        <h2 class="form-signin-heading">Modificar Cuenta</h2>                        
                            </div>
                        
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilApellido" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilDNI" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>                           
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilDomicilio" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilCelular" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="PerfilEmail" runat="server" CssClass="form-control" TextMode="Email" ReadOnly="true"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <%--<div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterPassword" runat="server" CssClass="form-control" placeholder="Ingrese password..." TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterRePassword" runat="server" CssClass="form-control" placeholder="Confirme password..." TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>          --%>              

                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success btn-block" OnClientClick="return ConfirmarModificacion();" OnClick="BtnGuardar_Click"/>
                        </div>

                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary btn-block" OnClick="BtnCancelar_Click"/>
                        </div>

                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger btn-block" OnClientClick="return ConfirmarEliminacion();"  OnClick="BtnEliminarCuenta_Click"/>
                            <%--<asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger btn-block" OnClick="ConfirmDelete()"/>--%>
                        </div>
                        
                    </form>
                </div>
            </div>
        </div>
        <!-- /container -->
        <asp:TableRow runat="server">
                           <asp:TableCell ColumnSpan="2" runat="server">
                            <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                            <asp:Label runat="server" CssClass="alert-danger" ID="lblErrorContrasenia"></asp:Label>
                           </asp:TableCell>
                          </asp:TableRow>

    </LayoutTemplate>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>