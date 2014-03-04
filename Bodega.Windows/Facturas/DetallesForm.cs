using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega.Entidades;
using Bodega.Negocio;
using Microsoft.Practices.Unity;
using Bodega.Plantillas;

namespace Bodega.Windows.Facturas
{
    public partial class DetallesForm : PlantillaMantenimiento
    {
        internal DetalleFacturaNegocio detalle;
        private IUnityContainer container;
        private ProductoNegocio productoNegocio;

        public DetallesForm()
        {
            InitializeComponent();
        }

        public DetallesForm(IUnityContainer _container, DetalleFacturaNegocio _detalle)
        {
            InitializeComponent();

            container = _container;
            detalle = _detalle;

            productoNegocio = container.Resolve<ProductoNegocio>();

            detallesBindingSource.DataSource = detalle;
            detallesBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                productoBindingSource.DataSource = productoNegocio.Listar();
                productoBindingSource.ResetBindings(false);
            };

            productoComboBox.SelectedValueChanged += (s, e) =>
                {
                    var lista = productoBindingSource.DataSource as List<Producto>;
                    if (lista == null) return;

                    var seleccionado = lista[productoComboBox.SelectedIndex];
                    if (seleccionado == null) return;

                    detalle.IdProducto = seleccionado.IdProducto;
                    detalle.DescripcionProducto = seleccionado.Descripcion;
                    detalle.PrecioUnitario = seleccionado.PrecioUnitario;
                    detallesBindingSource.ResetBindings(false);
                };
        }

        protected override void Guardar()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void Cancelar()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

       
    }
}
