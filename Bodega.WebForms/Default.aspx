<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bodega.WebForms.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

    <asp:Label ID="Label2" runat="server" Text="Lista de Facturas Generadas"></asp:Label>
    <br />
    <asp:GridView ID="gdvFacturas" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CLIENTE" HeaderText="CLIENTE" SortExpression="CLIENTE" />
            <asp:BoundField DataField="NUMERO" HeaderText="NUMERO" SortExpression="NUMERO" />
            <asp:BoundField DataField="SERIE" HeaderText="SERIE" SortExpression="SERIE" />
            <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
            <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:c}" HeaderText="SUBTOTAL" SortExpression="SUBTOTAL" />
            <asp:BoundField DataField="IMPUESTOS" DataFormatString="{0:c}" HeaderText="IMPUESTOS" SortExpression="IMPUESTOS" />
            <asp:BoundField DataField="TOTAL" DataFormatString="{0:c}" HeaderText="TOTAL" SortExpression="TOTAL" />
        </Columns>
    </asp:GridView>
    
</asp:Content>
