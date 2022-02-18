<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="e_comcerce.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>UTN E-Commerce | Registrar</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <LayoutTemplate>
        <div class="container">
            <div class="row" style="padding-top: 12px;"></div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2 text-center">
                    <form class="form-signin">
                        <div class="form-group col-md-10 text-center">
                        <h2 class="form-signin-heading">Registrar Cuenta</h2>                        
                            </div>
                        
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterNombre" runat="server" CssClass="form-control" Style="align: center" placeholder="Ingrese nombre..."></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterApellido" runat="server" CssClass="form-control" placeholder="Ingrese apellido..." TextMode="SingleLine"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI..." TextMode="Number"></asp:TextBox>                           
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterDomicilio" runat="server" CssClass="form-control" placeholder="Ingrese Domicilio..." TextMode="SingleLine"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterCelular" runat="server" CssClass="form-control" placeholder="Ingrese Celular..." TextMode="Number"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="RegisterUsuario" runat="server" CssClass="form-control" placeholder="Ingrese Usuario..." TextMode="Email"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-8 col-md-offset-2 text-center">
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
                        </div>
                        <div class="form-group col-md-8">
                            <div class="icheck-primary">
                                <input type="checkbox" id="agreeTerms" name="terms" value="agree">
                                <label for="agreeTerms" >
                                    Acepto los <a href="#">terminos</a>
                                </label>
                            </div>
                        </div>


                        <div class="form-group col-md-8 col-md-offset-2 text-center">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-block" OnClick="BtnRegistrar_Click"/>
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