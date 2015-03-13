<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="consulta.aspx.cs" Inherits="consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Consulta</h2>
    </div>
    <div>
        <div class="col-lg-4">
            <label>Categoria</label>
            <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <label>Descuento</label>
            <asp:DropDownList CssClass="form-control" ID="ddlDescuento" runat="server"></asp:DropDownList>
        </div>
        
        <div class="col-lg-4">
            <label>Ruta</label>
            <asp:DropDownList ID="ddlRuta" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <label>Tarjeta</label>
            <asp:TextBox ID="txtTarjeta" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="col-lg-4">
            <label>Fecha Inicio</label>
            <asp:TextBox ID="txtFechaIni" runat="server"  CssClass="form-control"></asp:TextBox>
            <br />
            <label>Fecha Fin</label>
            <asp:TextBox ID="txtFechaFin" runat="server"  CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-primary" Text="Consultar" OnClick="btnConsultar_Click" />
    </div>
    <br />
    <div>
        <asp:GridView ID="gvConsulta" runat="server" CssClass="table" AutoGenerateColumns="false">
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


