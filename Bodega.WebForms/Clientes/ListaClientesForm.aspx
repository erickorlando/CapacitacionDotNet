<%@ Page Title="Lista de Clientes" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="ListaClientesForm.aspx.cs" Inherits="Bodega.WebForms.Clientes.ListaClientesForm" %>

<%@ Register TagPrefix="bdg" Src="~/Controles/BarraBotonesLista.ascx" TagName="BarraBotones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

	<bdg:BarraBotones ID="barra" runat="server" />
	<br />
	<asp:GridView ID="gdvClientes" runat="server" AutoGenerateColumns="False">
		<Columns>
			<asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
			<asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
			<asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
			<asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
		</Columns>
	</asp:GridView>

</asp:Content>
