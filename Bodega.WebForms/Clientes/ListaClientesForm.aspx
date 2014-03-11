<%@ Page Title="Lista de Clientes" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="ListaClientesForm.aspx.cs" Inherits="Bodega.WebForms.Clientes.ListaClientesForm" %>

<%@ Register TagPrefix="bdg" Src="~/Controles/BarraBotonesLista.ascx" TagName="BarraBotones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

	<bdg:BarraBotones ID="barra" runat="server" />
	<br />
	<asp:GridView ID="gdvClientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="IdCliente">
		<Columns>
			<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/manito.png" ShowSelectButton="True" />
			<asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" Visible="false" />
			<asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
			<asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
			<asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
			<asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
		</Columns>
		<FooterStyle BackColor="White" ForeColor="#000066" />
		<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
		<RowStyle ForeColor="#000066" />
		<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
		<SortedAscendingCellStyle BackColor="#F1F1F1" />
		<SortedAscendingHeaderStyle BackColor="#007DBB" />
		<SortedDescendingCellStyle BackColor="#CAC9C9" />
		<SortedDescendingHeaderStyle BackColor="#00547E" />
	</asp:GridView>

</asp:Content>
