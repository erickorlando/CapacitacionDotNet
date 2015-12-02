<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraBotonesAccion.ascx.cs" Inherits="Bodega.WebForms.Controles.BarraBotonesAccion" %>
<table>
	<tr>
		<td>
			<asp:Panel runat="server" ID="toolGuardar">
				<asp:ImageButton runat="server" ID="btnGuardar" AlternateText="Guardar" ImageUrl="~/images/Guardar_16x16.png" EnableViewState="False" />
				<asp:Label runat="server" ID="lblGuardar">Guardar</asp:Label>
			</asp:Panel>

		</td>
		<td>&nbsp;|
		</td>
		<td>
			<asp:Panel runat="server" ID="toolCancelar" EnableViewState="False">
				<asp:ImageButton runat="server" ID="btnCancelar" AlternateText="Cancelar" ImageUrl="~/images/Cancelar_16x16.png" />
				<asp:Label runat="server" ID="lblCancelar">Cancelar</asp:Label>
			</asp:Panel>
		</td>
	</tr>
</table>
