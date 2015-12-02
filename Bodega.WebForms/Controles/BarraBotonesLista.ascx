<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraBotonesLista.ascx.cs" Inherits="Bodega.WebForms.Controles.BarraBotonesLista" %>
<table>
	<tr>
		<td>
			<asp:Panel ID="toolNuevo" runat="server">
				<asp:ImageButton ID="btnNuevo" runat="server" AlternateText="Nuevo" ImageUrl="~/images/Nuevo_16x16.png" />
				<asp:Label ID="lblNuevo" runat="server" Text="Nuevo" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel ID="toolEditar" runat="server">
				<asp:ImageButton ID="btnEditar" runat="server" AlternateText="Ver/Editar" ImageUrl="~/images/Editar_16x16.png" />
				<asp:Label ID="lblEditar" runat="server" Text="Editar" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel ID="toolEliminar" runat="server">
				<asp:ImageButton ID="btnEliminar" runat="server" AlternateText="Eliminar" ImageUrl="~/images/Eliminar_16x16.png" />
				<asp:Label ID="lblEliminar" runat="server" Text="Eliminar" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel ID="toolBuscar" runat="server">
				<asp:ImageButton ID="btnBuscar" runat="server" AlternateText="Buscar" ImageUrl="~/images/Buscar_16x16.png" />
				<asp:Label ID="lblBuscar" runat="server" Text="Buscar" />
			</asp:Panel>
		</td>
	</tr>
</table>
