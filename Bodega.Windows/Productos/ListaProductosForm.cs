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
    public partial class ListaProductosForm : PlantillaLista
    {
        private IUnityContainer container;
        private ProductoNegocio target;

        public ListaProductosForm()
        {
            InitializeComponent();
        }

        public ListaProductosForm(IUnityContainer _container)
        {
            InitializeComponent();
            container = _container;
            target = container.Resolve<ProductoNegocio>();
        }

        private void Listar()
        {
            try
            {
                productoBindingSource.DataSource = target.Listar();
                productoBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text,  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void Nuevo()
        {
            using (var frm = new ProductosForm(container, new Entidades.Producto()))
            {
                frm.IsNew = true;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Listar();
            }
        }

        public override void Editar()
        {
            var seleccionado = productoBindingSource.Current as Producto;
            using (var frm = new ProductosForm(container, seleccionado))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Listar();
            }
        }

        public override void Eliminar()
        {
            var seleccionado = productoBindingSource.Current as Producto;
            if (seleccionado == null)
                return;

            if (MessageBox
                .Show("Esta seguro que desea eliminar el registro?",
                "Confirme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            target.GetByID(seleccionado.IdProducto);
            if (target.Eliminar())
                Listar();
        }

        public override void Buscar()
        {
            Listar();
        }

        private void ListaProductosForm_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
