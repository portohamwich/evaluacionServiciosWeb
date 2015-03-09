<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcliente.aspx.cs" Inherits="frmcliente" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-3 col-sm-3 col-md-3"></div>
    <div class="col-lg-6 col-md-6 col-sm-6">
    <h1>Registro de Cliente</h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Ap. Paterno:"></asp:Label>
        <asp:TextBox ID="txtPaterno" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Ap. Materno"></asp:Label>
        <asp:TextBox ID="txtMaterno" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Direccion:"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Ciudad:"></asp:Label>
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
        <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label7" runat="server" Text="C.P.:"></asp:Label>
        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label8" runat="server" Text="Telefono:"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label9" runat="server" Text="Correo:"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label10" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label11" runat="server" Text="Contraseña:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label12" runat="server" Text="Confirmar contraseña:"></asp:Label>
        <asp:TextBox ID="txtConfirmaPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
        <br />
    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
    </div>
    </div>
    <div class="col-lg-3 col-sm-3 col-md-3"></div>
</asp:Content>
