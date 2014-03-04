using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega.Negocio;
using Microsoft.Practices.Unity;
using Bodega.Plantillas;

namespace Bodega.Windows.Facturas
{
	public partial class FacturasForm : PlantillaMantenimiento
    {
        private IUnityContainer container;
        private FacturaNegocio target;
        private ClienteNegocio clienteNegocio;

        public FacturasForm()
        {
            InitializeComponent();

        }

        public FacturasForm(IUnityContainer _container)
        {
            container = _container;
            target = container.Resolve<FacturaNegocio>();
            clienteNegocio = container.Resolve<ClienteNegocio>();

            InitializeComponent();

            detallesDataGridView.CellValueChanged += (s, e) =>
            {
                CalculaTotales();
                facturaNegocioBindingSource.ResetBindings(false);
            };
            detallesDataGridView.RowsAdded += (s, e) =>
            {
                CalculaTotales();
            };
            detallesDataGridView.RowsRemoved += (s, e) =>
            {
                CalculaTotales();
            };
        }

        private void CalculaTotales()
        {
            target.CalculaTotales(
                new CalculaMontosEventArgs(
                    target.Detalles
                    .Sum(d => d.Total)));
        }

        private void FacturasForm_Load(object sender, EventArgs e)
        {
            clientesBindingSource.DataSource =
                clienteNegocio.ListarClientes();
            clientesBindingSource.ResetBindings(false);

            facturaNegocioBindingSource.DataSource = target;
        }

        private void btmAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var detalle = new DetalleFacturaNegocio();
                using (var frm = new DetallesForm(container, detalle))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        target.Detalles.Add(frm.detalle);
                        facturaNegocioBindingSource.ResetBindings(false);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var seleccionado = detallesBindingSource.Current as DetalleFacturaNegocio;
                if (seleccionado == null)
                    return;

                target.Detalles.Remove(seleccionado);

                facturaNegocioBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void Guardar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                facturaNegocioBindingSource.EndEdit();
                target.Crear();
                if (target.Guardar())
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void Cancelar()
        {
            facturaNegocioBindingSource.CancelEdit();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
