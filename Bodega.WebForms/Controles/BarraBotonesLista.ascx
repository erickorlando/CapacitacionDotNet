<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraBotonesLista.ascx.cs" Inherits="Bodega.WebForms.Controles.BarraBotonesLista" %>
<table>
	<tr>
		<td>
			<asp:Panel id="toolNuevo" runat="server">
				<asp:ImageButton ID="btnNuevo" runat="server" AlternateText="Nuevo" ImageUrl="~/Resources/Nuevo_16x16.png" />
				<asp:Label ID="lblNuevo" runat="server" Text="Nuevo" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel id="toolEditar" runat="server">
				<asp:ImageButton ID="btnEditar" runat="server" AlternateText="Ver/Editar" ImageUrl="~/Resources/Editar_16x16.png" />
				<asp:Label ID="lblEditar" runat="server" Text="Editar" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel id="toolEliminar" runat="server">
				<asp:ImageButton ID="btnEliminar" runat="server" AlternateText="Eliminar" ImageUrl="~/Resources/Eliminar_16x16.png" />
				<asp:Label ID="lblEliminar" runat="server" Text="Eliminar" />
			</asp:Panel>
		</td>
		<td>
			<asp:Panel id="toolBuscar" runat="server">
				<asp:ImageButton ID="btnBuscar" runat="server" AlternateText="Buscar" ImageUrl="~/Resources/Buscar_16x16.png" />
				<asp:Label ID="lblBuscar" runat="server" Text="Buscar" />
			</asp:Panel>
		</td>
	</tr>
</table>
