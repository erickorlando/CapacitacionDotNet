using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bodega.WebForms.Controles
{
    public partial class BarraBotonesLista : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNuevo.Click += (s, g) => Nuevo();
            btnEditar.Click += (s, g) => Editar();
            btnEliminar.Click += (s, g) => Eliminar();
            btnBuscar.Click += (s, g) => Buscar();
        }

        public void Nuevo()
        {
            BotonNuevo(this, EventArgs.Empty);
        }

        public void Editar()
        {
            BotonEditar(this, EventArgs.Empty);
        }

        public void Eliminar()
        {
            BotonEliminar(this, EventArgs.Empty);
        }

        public void Buscar()
        {
            BotonBuscar(this, EventArgs.Empty);
        }

        public event EventHandler BotonNuevo = delegate { };
		public event EventHandler BotonEditar = delegate { };
		public event EventHandler BotonEliminar = delegate { };
		public event EventHandler BotonBuscar = delegate { };
    }
}