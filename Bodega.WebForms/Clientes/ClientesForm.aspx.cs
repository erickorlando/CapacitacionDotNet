using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bodega.Negocio;
using Microsoft.Practices.Unity;

namespace Bodega.WebForms.Clientes
{
	public partial class ClientesForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				LoadData();

			Barra.BotonGuardar += () =>
			{
				// Recuperamos la sesión del Target.
				var target = Session["Target"] as ClienteNegocio;
				target.Repositorio.Entidad.Nombres = txtNombres.Text;
				target.Repositorio.Entidad.Apellidos = txtApellidos.Text;
				target.Repositorio.Entidad.Correo = txtCorreo.Text;
				target.Repositorio.Entidad.Edad = String.IsNullOrEmpty(txtEdad.Text) ? 0 : Convert.ToInt32(txtEdad.Text);
				target.Guardar();
				Response.Redirect("ListaClientesForm.aspx");
			};

			Barra.BotonCancelar += () =>
			{
				Response.Redirect("ListaClientesForm.aspx");
			};
		}

		public void LoadData()
		{
			var container = Session["Container"] as IUnityContainer;
			var target = container.Resolve<ClienteNegocio>();
			if (Session["IsNew"] == null)
				return;
			bool IsNew = (bool)Session["IsNew"];
			if (IsNew)
				target.Crear();
			else
				target.GetByID(Session["ID"].ToString());

			txtNombres.Text = target.Repositorio.Entidad.Nombres;
			txtApellidos.Text = target.Repositorio.Entidad.Apellidos;
			txtCorreo.Text = target.Repositorio.Entidad.Correo;
			txtEdad.Text = target.Repositorio.Entidad.Edad.ToString();

			Session["Target"] = target;
		}
	}
}