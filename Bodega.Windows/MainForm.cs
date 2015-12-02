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

namespace Bodega.Windows
{
    public partial class MainForm : Form
    {
        private IUnityContainer container;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IUnityContainer _container)
        {
            InitializeComponent();
            container = _container;
            treeOpciones.DoubleClick += (s,e) => NodoSeleccionado();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            treeOpciones.ExpandAll();

            Listar();
        }

        private void Listar()
        {
            try
            {
                using (var facturas = container.Resolve<FacturaNegocio>())
                {
                    facturasComplexBindingSource
                        .DataSource = facturas
                        .ListarRegistros();
                    facturasComplexBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NodoSeleccionado()
        {
            var nombreNodo = treeOpciones.SelectedNode.Name;
            switch (nombreNodo)
            {
                case "nodClientes":
                    using (var frm = new ListaClientesForm(container))
                    {
                        frm.ShowDialog();
                    }
                    break;
                case "nodProductos":
                    using (var frm = new ListaProductosForm(container))
                    {
                        frm.ShowDialog();
                    }
                    break;
                case "nodFacturas":
                    using (var frm = new Facturas.FacturasForm(container))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            Listar();
                        }
                    }
                    break;
            }
        }
    }
}
