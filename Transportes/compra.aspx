<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="compra.aspx.cs" Inherits="compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <asp:Panel ID="Panel1" runat="server">
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="lblNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Numero de tarjeta"></asp:Label>
            <asp:TextBox ID="lblNumero" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Código de seguridad"></asp:Label>
            <asp:TextBox ID="lblCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Cantidad de boletos"></asp:Label>
            <asp:TextBox ID="lblCantidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>

            <asp:Label ID="Label6" runat="server" Text="Descuento"></asp:Label>
            <asp:DropDownList ID="ddlDescuento" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Comprar" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <h1>La compra se ha realizado exitosamente</h1>
    </asp:Panel>
</asp:Content>

