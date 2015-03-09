<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viajes.aspx.cs" Inherits="viajes" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Viajes Disponibles</h1>
        <asp:GridView ID="GridView1" runat="server" CssClass="table">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Comprar" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
    

