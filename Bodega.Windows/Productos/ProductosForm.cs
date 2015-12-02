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

namespace Bodega.Windows
{
    public partial class ProductosForm : PlantillaMantenimiento
    {
        private IUnityContainer container;
        private ProductoNegocio target;

        public ProductosForm()
        {
            InitializeComponent();
        }

        public ProductosForm(IUnityContainer _container, Producto entidad)
        {
            InitializeComponent();
            container = _container;
            Entidad = entidad;
            Load += (s, e) =>
                {
                    target = container.Resolve<ProductoNegocio>();
                    if (IsNew)
                    {
                        target.Crear();
                        Entidad = target.EntidadProducto;
                    }
                    else
                    {
                        target.GetByID(entidad.IdProducto);
                        Entidad = target.EntidadProducto;
                    }

                    productoBindingSource.DataSource = Entidad;
                    productoBindingSource.ResetBindings(false);
                };
        }

        public bool IsNew { get; set; }
        public Producto Entidad { get; set; }

        protected override void Guardar()
        {
            productoBindingSource.EndEdit();
            target.EntidadProducto = Entidad;
            if (target.Guardar())
                base.Guardar();
            else
                base.Cancelar();
        }

        protected override void Cancelar()
        {
            productoBindingSource.CancelEdit();
            base.Cancelar();
            
        }
    }
}
