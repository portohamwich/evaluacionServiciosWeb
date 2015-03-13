<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-3 col-sm-3 col-md-3"></div>
    <div class="col-lg-6 col-md-6 col-sm-6">
        <h1>Ingreso de usuario</h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" CssClass="btn btn-primary" />
        </div>
        <a href="frmcliente.aspx">Regístrate</a>

    </div>
<div class="col-lg-3 col-sm-3 col-md-3"></div>
</asp:Content>

