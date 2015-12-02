using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bodega.WebForms.Controles
{
	public partial class BarraBotonesAccion : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			btnGuardar.Click += (s, g) => Guardar();
			btnCancelar.Click += (s, g) => Cancelar();
		}

		public void Cancelar()
		{
			BotonCancelar(this, EventArgs.Empty);
		}

		public void Guardar()
		{
			BotonGuardar(this, EventArgs.Empty);
		}

		public event EventHandler BotonGuardar = delegate {};
		public event EventHandler BotonCancelar = delegate {};
	}
}