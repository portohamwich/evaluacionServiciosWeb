<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="consulta.aspx.cs" Inherits="consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Consulta</h2>
    </div>
    <div>
        <label>Categoria</label>
        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
        <label>Descuento</label>
        <asp:DropDownList ID="ddlDescuento" runat="server"></asp:DropDownList>
        <label>Ruta</label>
        <asp:DropDownList ID="ddlRuta" runat="server"></asp:DropDownList>
        <label>Tarjeta</label>
        <asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox>
        <label>Fecha Inicio</label>
        <asp:TextBox ID="txtFechaIni" runat="server"></asp:TextBox>
        <label>Fecha Fin</label>
        <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
        <label>Consultar</label>
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
    </div>
    <div>
        <asp:GridView ID="gvConsulta" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Cliente" />
                <asp:BoundField DataField="origen" HeaderText="Origen" />
                <asp:BoundField DataField="destino" HeaderText="Destino" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
                <asp:BoundField DataField="marca" HeaderText="Marca" />
                <asp:BoundField DataField="categoria" HeaderText="Nombre" />
                <asp:BoundField DataField="nombrecorto" HeaderText="Descuento" />
                <asp:BoundField DataField="tarjeta" HeaderText="Tarjeta" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


