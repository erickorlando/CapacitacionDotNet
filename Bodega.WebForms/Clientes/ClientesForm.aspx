<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="ClientesForm.aspx.cs" Inherits="Bodega.WebForms.Clientes.ClientesForm" %>

<%@ Register Src="~/Controles/BarraBotonesAccion.ascx" TagPrefix="bdg" TagName="BarraAccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

	<bdg:BarraAccion runat="server" ID="Barra" />

	<table>
		<tr>
			<td>
				<asp:Label runat="server">Nombres:</asp:Label>
			</td>
			<td>
				<asp:TextBox ID="txtNombres" runat="server" />

			</td>
			<td>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
					runat="server" 
					ControlToValidate="txtNombres" 
					Display="Dynamic" 
					ErrorMessage="*" 
					SetFocusOnError="True" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server">Apellidos:</asp:Label>
			</td>
			<td>
				<asp:TextBox runat="server" ID="txtApellidos" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server">Correo:</asp:Label>
			</td>
			<td>
				<asp:TextBox runat="server" ID="txtCorreo" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server">Edad:</asp:Label>
			</td>
			<td>
				<asp:TextBox runat="server" ID="txtEdad" />
			</td>
		</tr>
	</table>
	
</asp:Content>
