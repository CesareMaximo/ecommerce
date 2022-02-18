<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="e_comcerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Nuestros mejores productos!</h1>
        <p class="lead">Podrás ver nuestros productos ordenados por categoria! .</p>
        <p><a href="<%: aux %>" class="btn btn-primary btn-lg">Hace click Acá! &raquo;</a></p>
        <img src="https://tiendacerca.com/static/assets/market/shop-red.gif" class="d-block w-100" width="1000px" alt="...">
    </div>
    <hr />

    <div class="jumbotron">
        <h1>Tenés algún problema? contacta con nostros!</h1>
        
        <p><a href="<%: contacto %>" class="btn btn-primary btn-lg">Hace click Acá! &raquo;</a></p>
        <img src="https://assets-global.website-files.com/5f4f67c5950db17954dd4f52/5f5b74f79bd6983b85d41918_06_CONTACTO_VIVUS.jpeg" class="d-block w-100" width="1000px" alt="...">
    </div>
    <hr />
    

</asp:Content>
