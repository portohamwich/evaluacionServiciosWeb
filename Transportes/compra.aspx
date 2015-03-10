<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="compra.aspx.cs" Inherits="compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Numero de tarjeta"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Numero de tarjeta"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Código de seguridad"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Cantidad de boletos"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Comprar" OnClick="Button1_Click" />
    </div>
</asp:Content>

