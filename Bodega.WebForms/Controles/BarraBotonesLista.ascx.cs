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
            BotonNuevo();
        }

        public void Editar()
        {
            BotonEditar();
        }

        public void Eliminar()
        {
            BotonEliminar();
        }

        public void Buscar()
        {
            BotonBuscar();
        }

        public event Action BotonNuevo = delegate { };
        public event Action BotonEditar = delegate { };
        public event Action BotonEliminar = delegate { };
        public event Action BotonBuscar = delegate { };
    }
}