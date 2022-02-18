<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_comcerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <asp:Login ID="frmLogin" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
        <LayoutTemplate>
            <!-- LOGIN FORM -->
            <div id="loginbox" style="margin-top: 50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info"  >
                    <div class="panel-heading">
                        <div class="panel-title">Iniciar Sesion</div>
                        <div style="float: right; font-size: 80%; position: relative; top: -10px"><a href="#">Ha olvidado su contraseña?</a></div>
                    </div>

                    <div style="padding-top: 30px" class="panel-body">

                        <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>

                        <form id="loginform" class="form-horizontal" role="form">

                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox ID="UserName" runat="server" CssClass="form-control" type="email" placeholder="Ingrese Email..."></asp:TextBox>                                
                            </div>

                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox ID="Password" runat="server" CssClass="form-control" min="5" placeholder="Ingrese Contraseña..." TextMode="Password"></asp:TextBox>                                
                            </div>

                            <div style="margin-top: 10px" class="form-group">
                                <!-- Button -->

                                <div class="col-sm-12 controls">
                                    <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesion" CssClass="btn btn-success" />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-12 control" style="margin-top: 10px">
                                    <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                        Usted no tiene una cuenta! 
                                        <a href="Registro.aspx">Click aqui para registrarse
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
